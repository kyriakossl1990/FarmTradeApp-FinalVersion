using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}