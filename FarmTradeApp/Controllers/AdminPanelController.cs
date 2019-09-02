using FarmTradeApp.Helpers;
using FarmTradeApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmTradeApp.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class AdminPanelController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminPanelController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

        //Get user contact
        public ActionResult ViewAllContactForms()
        {
            return View(unitOfWork.ContactForms.GetContactForms());
        }

        // Get user contact form + User Id
        public ActionResult ViewUserContactForms(int Id)
        {
            return View(unitOfWork.ContactForms.GetContactForm(Id));
        }

        public ActionResult ViewUser(string Id)
        {
            return View(unitOfWork.Users.GetUser(Id));
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult MarkAsViewed(int Id)
        {
            var ReadForm = unitOfWork.ContactForms.GetContactForm(Id);
            ReadForm.Answered();
            unitOfWork.Complete();
            return RedirectToAction("ViewAllContactForms");
        }
    }
}