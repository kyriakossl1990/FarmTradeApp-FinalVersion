using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Contacts
{
    public class VerificationForm
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime TimeFormSubmitted { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsAccepted { get; set; }

        private VerificationForm()
        {
            TimeFormSubmitted = DateTime.Now;
        }

        public VerificationForm(ApplicationUser user)
        {
            UserId = user.Id;
            User = user;
        }

        public static VerificationForm CreateVerificationForm()
        {
            return new VerificationForm();
        }
    }
}