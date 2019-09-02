using FarmTradeApp.Persistence;
using FarmTradeApp.Helpers;
using FarmTradeApp.Core.Models.Products;
using FarmTradeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FarmTradeApp.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = unitOfWork.Products.GetProductsWithCategoryAndName();

            return View(products);
        }

        // GET
        public ActionResult New()
        {
            var viewModel = new ProductViewModel()
            {
                Product = new Product(),
                ProductCategories = unitOfWork.ProductCategories.GetProductCategories()
            };

            return View(ViewName.ProductForm, viewModel);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductViewModel()
                {
                    Product = product,
                    ProductCategories = unitOfWork.ProductCategories.GetProductCategories()
                };

                return View(ViewName.ProductForm, viewModel);
            }

            if (product.Id == 0) // create
                unitOfWork.Products.Add(product);
            else // edit
            {
                var productDB = unitOfWork.Products.GetProduct(product.Id);
                productDB.Name = product.Name;
                productDB.CategoryId = product.CategoryId;
            }

            unitOfWork.Complete();
            return RedirectToAction("Index", "Products");
        }

        public ActionResult Delete(int id)
        {
            var product = unitOfWork.Products.GetProduct(id);

            if (product == null)
                return HttpNotFound();
            else
                unitOfWork.Products.Remove(product);

            unitOfWork.Complete();

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Edit(int id)
        {
            var product = unitOfWork.Products.GetProduct(id);

            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductViewModel()
            {
                Product = product,
                ProductCategories = unitOfWork.ProductCategories.GetProductCategories()
            };

            return View(ViewName.ProductForm, viewModel);
        }
    }
}