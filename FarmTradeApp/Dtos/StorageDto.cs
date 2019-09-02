using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Dtos
{
    public class StorageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }

        public int LocationId { get; set; }

        public LocationDto Location { get; set; }
    }
}