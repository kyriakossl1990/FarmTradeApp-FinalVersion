using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
{
    public class FinalProductDto
    {
        public int Id { get; set; }
        public DateTime ImportDateToStorage { get; set; }
        public DateTime? ExportDateFromStorage { get; set; }
        public bool IsOrganic { get; set; }
        public string Comments { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int QualityId { get; set; }
        public ProductQualityDto Quality { get; set; }

        public string UserId { get; set; }
        public ApplicationUserDto User { get; set; }

        public int LocationId { get; set; }
        public LocationDto Location { get; set; }

        public int? StorageId { get; set; }
        public StorageDto Storage { get; set; }
    }
}