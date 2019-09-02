using FarmTradeApp.Core.Models;
using FarmTradeApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.ViewModels
{
    public class FinalProductFormViewModel
    {
        public FinalProduct FinalProduct { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductQuality> ProductQualities { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Storage> Storages { get; set; }
    }
}