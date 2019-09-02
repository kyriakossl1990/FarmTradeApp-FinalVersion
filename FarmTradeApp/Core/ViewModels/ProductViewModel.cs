using FarmTradeApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}