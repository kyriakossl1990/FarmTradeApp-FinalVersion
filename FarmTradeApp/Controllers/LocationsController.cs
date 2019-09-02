using FarmTradeApp.Persistence;
using FarmTradeApp.Helpers;
using FarmTradeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmTradeApp.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class LocationsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public LocationsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Product
        public ActionResult Index()
        {
            var locations = unitOfWork.Locations.GetLocationsOrderedByCity();

            return View(locations);
        }

        // GET
        public ActionResult New()
        {
            var location = new Location();

            return View(ViewName.LocationForm, location);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(ViewName.LocationForm, location);
            }

            if (location.Id == 0) // create
                unitOfWork.Locations.Add(location);
            else // edit
            {
                var locationDB = unitOfWork.Locations.GetLocation(location.Id);
                locationDB.City = location.City;
                locationDB.PostalCode = location.PostalCode;
            }

            unitOfWork.Complete();

            return RedirectToAction("Index", "Locations");
        }

        public ActionResult Delete(int id)
        {
            var location = unitOfWork.Locations.GetLocation(id);

            if (location == null)
                return HttpNotFound();
            else
                unitOfWork.Locations.Remove(location);

            unitOfWork.Complete();

            return RedirectToAction("Index", "Locations");
        }

        public ActionResult Edit(int id)
        {
            var location = unitOfWork.Locations.GetLocation(id);

            if (location == null)
                return HttpNotFound();

            var viewModel = new Location()
            {
                City = location.City,
                PostalCode = location.PostalCode
            };

            return View(ViewName.LocationForm, viewModel);
        }
    }
}