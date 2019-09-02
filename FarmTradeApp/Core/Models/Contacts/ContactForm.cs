using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Contacts
{
    public class ContactForm
    {
        public int Id { get; set; }
        public DateTime TimeFormSent { get; set; }
        public bool IsAnswered { get; set; }

        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        [Display(Name = "Departments")]
        public ContactFormType ContactFormType { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public ContactForm()
        { }

        public ContactForm(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException("User cannot be null");

            SenderId = user.Id;
            Sender = user;
            TimeFormSent = DateTime.Now;
        }

        public void Answered()
        {
            IsAnswered = true;
        }
    }
}