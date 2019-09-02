using FarmTradeApp.DAL;
using FarmTradeApp.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Repositories
{
    public class ProductQualityRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductQualityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductQuality> GetProductQualities()
        {
            return _context.ProductQualities.ToList();
        }
    }
}