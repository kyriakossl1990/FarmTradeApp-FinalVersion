using FarmTradeApp.Persistence;
using FarmTradeApp.Helpers;
using FarmTradeApp.Core.Models.Market;
using FarmTradeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmTradeApp.Core.Models.Contacts;
using Microsoft.AspNet.Identity;

namespace FarmTradeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        // Get
        [Authorize]
        public ActionResult SentPm()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SentPm(PersonalMessage pm)
        {
            return View();
        }


        // Get/Contact
        [Authorize]
        public ActionResult Contact()
        {
            return View(new ContactForm(unitOfWork.Users.GetUser(User.Identity.GetUserId())));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactForm contactForm)
        {
            if (!ModelState.IsValid)
                return View(contactForm);

            contactForm.Sender = unitOfWork.Users.GetUser(contactForm.SenderId);

            unitOfWork.ContactForms.Add(contactForm);
            unitOfWork.Complete();

            return View("SuccessContactForm", contactForm);
        }

        //// Get /Home/VerificationForm
        //[Authorize]
        //public ActionResult VerificationForm()
        //{
        //    return View(unitOfWork.Users
        //        .GetUserWithVerificationForm(User.Identity.GetUserId()));
        //}

        // Get /Home/VerificationForm
        [Authorize]
        public ActionResult VerificationForm()
        {
            return View(new VerificationForm(unitOfWork.Users
                .GetUserWithVerificationForm(User.Identity.GetUserId())));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerificationForm(VerificationForm verificationForm)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Tos()
        {
            ViewBag.Message = "Your Term Of Service page.";

            return View();
        }

        public ActionResult Faq()
        {
            ViewBag.Message = "Your Faq page.";

            return View();
        }

        [Authorize]
        public ActionResult Market(int? id)
        {
            Auction auction = null;

            if (id == null || id == 0)
                auction = unitOfWork.Auctions.GetActiveAuction();
            else
                auction = unitOfWork.Auctions.GetAuction(id);

            if (auction == null)
                return HttpNotFound();

            var viewModel = new MarketPlace
            {
                Id = auction.Id,
                IsActive = auction.AuctionEndDate > DateTime.Now,
                EndTime = auction.AuctionEndDate.ToString(),
                EndTimeGreek = auction.AuctionEndDate.AddSeconds(-1).ToString("D", CultureInfo.CreateSpecificCulture("el-GR")),
                HasEntries = auction.MarketEntries.Any()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Market(MarketPlace viewModel)
        {
            return RedirectToAction(ViewName.Market, new { id = viewModel.Id });
        }
    }
}