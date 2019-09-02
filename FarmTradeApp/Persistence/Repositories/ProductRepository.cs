using FarmTradeApp.Persistence;
using FarmTradeApp.Core.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FarmTradeApp.Core.Repositories;

namespace FarmTradeApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProductsWithCategoryAndName()
        {
            return _context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.Name)
                .ToList();
        }

        public Product GetProduct(int productId)
        {
            return _context.Products.Single(p => p.Id == productId);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}