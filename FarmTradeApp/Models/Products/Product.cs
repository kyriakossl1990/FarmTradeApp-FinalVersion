using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public short CategoryId { get; set; }

        public ProductCategory Category { get; set; }
    }
}