using FarmTradeApp.Persistence;
using FarmTradeApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FarmTradeApp.Core.Models.Products;
using FarmTradeApp.Core.ViewModels;
using Microsoft.AspNet.Identity;

namespace FarmTradeApp.Controllers
{
    [Authorize]
    public class FinalProductsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public FinalProductsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: FinalProduct
        public ActionResult Index()
        {
            var finalProducts = new List<FinalProduct>();

            if (User.IsInRole(RoleName.Seller))
            {
                var userId = User.Identity.GetUserId();

                finalProducts
                    .AddRange(unitOfWork.FinalProducts.GetFullFinalProducts(userId)
                    .ToList());
            }
            else
            {
                var role = unitOfWork.Roles.GetRole(RoleName.Seller);

                finalProducts
                    .AddRange(unitOfWork.FinalProducts.GetSellerFullFinalProducts(role.Id)
                    .ToList());
            }

            return View(finalProducts);
        }

        // GET
        [Authorize(Roles = RoleName.Seller)]
        public ActionResult New()
        {
            var viewModel = new FinalProductFormViewModel()
            {
                FinalProduct = new FinalProduct(),
                Locations = unitOfWork.Locations.GetLocations(),
                Storages = unitOfWork.Storages.GetStorages(),
                Products = unitOfWork.Products.GetProducts(),
                ProductQualities = unitOfWork.ProductQualities.GetProductQualities()
            };
            viewModel.FinalProduct.UserId = User.Identity.GetUserId();

            return View(ViewName.FinalProductForm, viewModel);
        }

        [Authorize(Roles = RoleName.Seller)]
        public ActionResult Save(FinalProduct finalProduct)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FinalProductFormViewModel()
                {
                    FinalProduct = finalProduct,
                    Products = unitOfWork.Products.GetProducts(),
                    ProductQualities = unitOfWork.ProductQualities.GetProductQualities(),
                    Locations = unitOfWork.Locations.GetLocations(),
                    Storages = unitOfWork.Storages.GetStorages()
                };
                return View(ViewName.FinalProductForm, viewModel);
            }

            if (finalProduct.Id == 0) // create
            {
                finalProduct.UserId = User.Identity.GetUserId();
                unitOfWork.FinalProducts.Add(finalProduct);
            }
            else // edit
            {
                var finalProductDB = unitOfWork.FinalProducts.GetFinalProduct(finalProduct.Id);
                finalProductDB.UserId = User.Identity.GetUserId();
                finalProductDB.ProductId = finalProduct.ProductId;
                finalProductDB.QualityId = finalProduct.QualityId;
                finalProductDB.LocationId = finalProduct.LocationId;
                finalProductDB.ImportDateToStorage = finalProduct.ImportDateToStorage;
                finalProductDB.ExportDateFromStorage = finalProduct.ExportDateFromStorage;
                finalProductDB.IsOrganic = finalProduct.IsOrganic;
                finalProductDB.Comments = finalProduct.Comments;
            }

            unitOfWork.Complete();
            return RedirectToAction("Index", "FinalProducts");
        }

        [Authorize(Roles = RoleName.Seller)]
        public ActionResult Edit(int id)
        {
            var finalProduct = unitOfWork.FinalProducts.GetFinalProduct(id);

            if (finalProduct == null)
                return HttpNotFound();

            var viewModel = new FinalProductFormViewModel()
            {
                FinalProduct = finalProduct,
                Locations = unitOfWork.Locations.GetLocations(),
                Storages = unitOfWork.Storages.GetStorages(),
                Products = unitOfWork.Products.GetProducts(),
                ProductQualities = unitOfWork.ProductQualities.GetProductQualities()
            };

            return View(ViewName.FinalProductForm, viewModel);
        }
    }
}