using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
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