using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Contacts
{
    public class PersonalMessage
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsViewed { get; set; }
        public DateTime TimeSent { get; set; }

        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
    }
}