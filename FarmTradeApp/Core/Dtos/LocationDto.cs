using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}