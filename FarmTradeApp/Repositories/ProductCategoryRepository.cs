using FarmTradeApp.DAL;
using FarmTradeApp.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Repositories
{
    public class ProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return _context.ProductCategories.ToList();
        }
    }
}