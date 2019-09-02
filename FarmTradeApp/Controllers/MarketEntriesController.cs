using FarmTradeApp.Persistence;
using FarmTradeApp.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FarmTradeApp.Core.ViewModels;
using FarmTradeApp.Core.Models.Products;
using FarmTradeApp.Core.Models.Market;

namespace FarmTradeApp.Controllers
{
    public class MarketEntriesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public MarketEntriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Index
        [Authorize]
        public ActionResult Index()
        {
            var marketEntries = unitOfWork.MarketEntries.GetUserMarketEntriesWithFinalProduct();

            return View(marketEntries);
        }

        // GET: Details
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(id);
        }

        // GET: Edit
        [Authorize(Roles = RoleName.BuyerOrSeller)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var marketEntry = unitOfWork.MarketEntries
                .GetMarketEntryWithFinalProductAndAuction(id);

            if (marketEntry == null)
                return HttpNotFound();

            // Check for users to be able to edit only their market entries of active auction only
            if (marketEntry.Auction.IsCompleted && marketEntry.UserId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var finalProducts = new List<FinalProduct>();
            var products = new List<Product>();
            var productQualities = new List<ProductQuality>();
            PopulateLists(finalProducts, products, productQualities);

            var viewModel = new MarketEntryFormViewModel()
            {
                Id = marketEntry.Id,
                DeliveryDate = marketEntry.DeliveryDate,
                EntryQuantity = marketEntry.EntryQuantity,
                EntryPrice = marketEntry.EntryPrice,
                DeliveryLocation = marketEntry.DeliveryLocation,
                FinalProductId = marketEntry.FinalProductId,
                ProductId = marketEntry.FinalProduct.ProductId,
                ProductQualityId = marketEntry.FinalProduct.QualityId,
                Products = User.IsInRole(RoleName.Buyer) ? products : new List<Product>(),
                ProductQualities = User.IsInRole(RoleName.Buyer) ? productQualities : new List<ProductQuality>(),
                FinalProducts = User.IsInRole(RoleName.Seller) ? finalProducts : new List<FinalProduct>(),
                IsBuyerForm = User.IsInRole(RoleName.Buyer),
                FinalProductsAvailable = true,
                Heading = "Επεξεργασία Καταχώρισης"
            };

            return View(ViewName.MarketEntryForm, viewModel);
        }

        // Populate ViewModel Collections
        private void PopulateLists(List<FinalProduct> finalProducts, List<Product> products, List<ProductQuality> productQualities)
        {
            var userId = User.Identity.GetUserId();

            if (User.IsInRole(RoleName.Buyer))
            {
                finalProducts
                    .AddRange(unitOfWork.FinalProducts.GetFinalProductsWIthQualityAndProduct()
                    .ToList());
            }
            else
            {
                finalProducts
                    .AddRange(unitOfWork.FinalProducts.GetUserFinalProductsWIthQualityAndProduct(userId)
                    .ToList());
            }

            products.AddRange(finalProducts.Select(fp => fp.Product).Distinct().OrderBy(p => p.Name));
            productQualities.AddRange(finalProducts.Select(fp => fp.Quality).Distinct().OrderBy(q => q.Grade));
        }

        // GET: New
        [Authorize(Roles = RoleName.BuyerOrSeller)]
        public ActionResult New()
        {
            var finalProducts = new List<FinalProduct>();
            var products = new List<Product>();
            var productQualities = new List<ProductQuality>();
            PopulateLists(finalProducts, products, productQualities);

            var viewModel = new MarketEntryFormViewModel()
            {
                DeliveryDate = DateTime.Now,
                Products = User.IsInRole(RoleName.Buyer) ? products : new List<Product>(),
                ProductQualities = User.IsInRole(RoleName.Buyer) ? productQualities : new List<ProductQuality>(),
                FinalProducts = User.IsInRole(RoleName.Seller) ? finalProducts : new List<FinalProduct>(),
                IsBuyerForm = User.IsInRole(RoleName.Buyer),
                FinalProductsAvailable = User.IsInRole(RoleName.Buyer),
                Heading = User.IsInRole(RoleName.Buyer) ? "Φόρμα Ζήτησης" : "Φόρμα Προσφοράς"
            };

            if (User.IsInRole(RoleName.Seller) && viewModel.FinalProducts.Any())
                viewModel.FinalProductsAvailable = true;

            return View(ViewName.MarketEntryForm, viewModel);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.BuyerOrSeller)]
        public ActionResult Create(MarketEntryFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var activeAuction = unitOfWork.Auctions.GetActiveAuction();

            var finalProducts = new List<FinalProduct>();
            var products = new List<Product>();
            var productQualities = new List<ProductQuality>();
            PopulateLists(finalProducts, products, productQualities);

            if (!ModelState.IsValid)
            {
                viewModel.Products = User.IsInRole(RoleName.Buyer) ? products : new List<Product>();
                viewModel.ProductQualities = User.IsInRole(RoleName.Buyer) ? productQualities : new List<ProductQuality>();
                viewModel.FinalProducts = User.IsInRole(RoleName.Seller) ? finalProducts : new List<FinalProduct>();
                viewModel.IsBuyerForm = User.IsInRole(RoleName.Buyer);

                return View(ViewName.MarketEntryForm, viewModel);
            }

            if (User.IsInRole(RoleName.Buyer))
                activeAuction.AddBuyerMarketEntry(viewModel, userId);
            else if (User.IsInRole(RoleName.Seller))
                activeAuction.AddSellerMarketEntry(viewModel, userId);

            unitOfWork.Complete();

            return RedirectToAction(ViewName.Market, "Home");
        }

        // POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.BuyerOrSeller)]
        public ActionResult Update(MarketEntryFormViewModel viewModel)
        {
            var finalProducts = new List<FinalProduct>();
            var products = new List<Product>();
            var productQualities = new List<ProductQuality>();
            PopulateLists(finalProducts, products, productQualities);

            if (!ModelState.IsValid)
            {
                viewModel.Products = User.IsInRole(RoleName.Buyer) ? products : new List<Product>();
                viewModel.ProductQualities = User.IsInRole(RoleName.Buyer) ? productQualities : new List<ProductQuality>();
                viewModel.FinalProducts = User.IsInRole(RoleName.Seller) ? finalProducts : new List<FinalProduct>();
                viewModel.IsBuyerForm = User.IsInRole(RoleName.Buyer);

                return View(ViewName.MarketEntryForm, viewModel);
            }

            var marketEntry = unitOfWork.MarketEntries
                .GetMarketEntryWithFinalProduct(viewModel.Id);

            if (marketEntry == null)
                return HttpNotFound();

            if (marketEntry.UserId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            marketEntry.Modify(viewModel);

            unitOfWork.Complete();

            return RedirectToAction(ViewName.Market, "Home");
        }
    }
}