using FarmTradeApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FarmTradeApp.Models.Market;

namespace FarmTradeApp.Repositories
{
    public class MarketEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public MarketEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MarketEntry GetMarketEntryWithFinalProductAndAuction(int? marketEntryId)
        {
            return _context.MarketEntries
                .Include(e => e.FinalProduct)
                .Include(e => e.Auction)
                .FirstOrDefault(e => e.Id == marketEntryId);
        }

        public MarketEntry GetMarketEntryWithFinalProduct(int marketEntryId)
        {
            return _context.MarketEntries
                .Include(e => e.FinalProduct)
                .SingleOrDefault(e => e.Id == marketEntryId);
        }

        public IEnumerable<MarketEntry> GetUserMarketEntriesWithFinalProduct()
        {
            return _context.MarketEntries                    
                .Where(m => !m.IsRemoved)
                .Include(me => me.FinalProduct.Product)
                .Include(me => me.FinalProduct.Quality)
                .Include(m => m.User)
                .ToList();
        }
    }
}