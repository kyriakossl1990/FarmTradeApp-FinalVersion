using FarmTradeApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models
{
    public class Storage
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(100)]
        public string Name { get; set; }

        //[Required]
        //[StringLength(100)]
        public string Street { get; set; }

        [Display(Name = "Πόλη")]
        public int LocationId { get; set; }

        public Location Location { get; set; }

        public ICollection<FinalProduct> FinalProducts { get; set; }
    }
}