using FarmTradeApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FarmTradeApp.Core.Models.Market;
using FarmTradeApp.Core.Repositories;

namespace FarmTradeApp.Repositories
{
    public class MarketEntryRepository : IMarketEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public MarketEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MarketEntry GetMarketEntry(int marketEntryId)
        {
            return _context.MarketEntries.SingleOrDefault(e => e.Id == marketEntryId);
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

        public MarketEntry GetFullMarketEntry(int marketEntryId)
        {
            return _context.MarketEntries
                .Include(m => m.Auction)
                .Include(m => m.FinalProduct.Product)
                .Include(m => m.FinalProduct.Quality)
                .SingleOrDefault(m => m.Id == marketEntryId && !m.IsRemoved);
        }

        public IEnumerable<MarketEntry> GetUserMarketEntriesWithFinalProduct()
        {
            return _context.MarketEntries   
                .Include(me => me.Auction)
                .Include(me => me.FinalProduct.Product)
                .Include(me => me.FinalProduct.Quality)
                .Include(m => m.User)
                .Where(m => !m.IsRemoved)
                .ToList();
        }

        public void Add(MarketEntry marketEntry)
        {
            _context.MarketEntries.Add(marketEntry);
        }
    }
}