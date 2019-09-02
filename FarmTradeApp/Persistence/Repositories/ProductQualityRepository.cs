using FarmTradeApp.Persistence;
using FarmTradeApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmTradeApp.Core.Repositories;

namespace FarmTradeApp.Repositories
{
    public class ProductQualityRepository : IProductQualityRepository
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