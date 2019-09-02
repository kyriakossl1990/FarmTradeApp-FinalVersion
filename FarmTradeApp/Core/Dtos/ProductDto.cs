using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public ProductCategoryDto Category { get; set; }
    }
}