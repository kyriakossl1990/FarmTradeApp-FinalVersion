using FarmTradeApp.Persistence;
using FarmTradeApp.Helpers;
using FarmTradeApp.Core.Models;
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
    public class StoragesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public StoragesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Edit(int id)
        {
            var storage = unitOfWork.Storages.GetStorage(id);

            if (storage == null)
                return HttpNotFound();

            var viewModel = new StorageFormViewModel()
            {
                Storage = storage,
                Locations = unitOfWork.Locations.GetLocations()
            };

            return View("StorageForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Storage storage)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StorageFormViewModel()
                {
                    Storage = storage,
                    Locations = unitOfWork.Locations.GetLocations()
                };

                return View("StorageForm", viewModel);
            }

            if (storage.Id == 0)// create
                unitOfWork.Storages.AddStorage(storage);
            else // edit
            {
                var storageDb = unitOfWork.Storages.GetStorage(storage.Id);
                storageDb.Name = storage.Name;
                storageDb.LocationId = storage.LocationId;
                storageDb.Street = storage.Street;
            }

            unitOfWork.Complete();

            return RedirectToAction("Index", "Storages");
        }

        public ActionResult New()
        {
            var viewModel = new StorageFormViewModel()
            {
                Storage = new Storage(),
                Locations = unitOfWork.Locations.GetLocations()
            };

            return View("StorageForm", viewModel);
        }

        // GET: Storages
        public ActionResult Index()
        {
            return View();
        }
    }
}