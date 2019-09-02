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
    public class FinalProductRepository : IFinalProductRepository
    {
        private readonly ApplicationDbContext _context;

        public FinalProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public FinalProduct GetFinalProduct(int finalProductId)
        {
            return _context.FinalProducts.Single(f => f.Id == finalProductId);
        }

        public IEnumerable<FinalProduct> GetFinalProductsWIthQualityAndProduct()
        {
            return _context.FinalProducts
                .Include(fp => fp.Quality)
                .Include(fp => fp.Product);
        }

        public IEnumerable<FinalProduct> GetUserFinalProductsWIthQualityAndProduct(string userId)
        {
            return _context.FinalProducts
                .Include(fp => fp.Quality)
                .Include(fp => fp.Product)
                .Where(p => p.UserId == userId);
        }

        public IEnumerable<FinalProduct> GetFullFinalProducts(string userId)
        {
            return _context.FinalProducts
                    .Include(f => f.User)
                    .Include(f => f.Product.Category)
                    .Include(f => f.Quality)
                    .Include(f => f.Location)
                    .Include(f => f.Storage)
                    .Where(f => f.UserId == userId);
        }

        public IEnumerable<FinalProduct> GetSellerFullFinalProducts(string roleId)
        {
            return _context.FinalProducts
                    .Include(f => f.User)
                    .Include(f => f.Product)
                    .Include(f => f.Product.Category)
                    .Include(f => f.Quality)
                    .Include(f => f.Location)
                    .Include(f => f.Storage)
                    .Where(f => f.User.Roles.Any(r => r.RoleId == roleId));
        }

        public void Add(FinalProduct finalProduct)
        {
            _context.FinalProducts.Add(finalProduct);
        }
    }
}