using FarmTradeApp.Persistence;
using FarmTradeApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmTradeApp.Core.Repositories;

namespace FarmTradeApp.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
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