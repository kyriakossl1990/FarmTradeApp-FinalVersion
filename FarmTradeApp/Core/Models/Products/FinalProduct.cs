using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Products
{
    public class FinalProduct
    {
        public int Id { get; set; }
        public DateTime? ImportDateToStorage { get; set; }
        public DateTime? ExportDateFromStorage { get; set; }
        public bool IsOrganic { get; set; }
        public string Comments { get; set; }
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Επιλέξτε ένα προϊόν")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "Επιλέξτε ποιότητα προϊόντος")]
        public byte QualityId { get; set; }

        public ProductQuality Quality { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }

        public int? StorageId { get; set; }
        public Storage Storage { get; set; }

        public void Modify(int productId, byte qualityId)
        {
            ProductId = productId;
            QualityId = qualityId;
        }
    }
}