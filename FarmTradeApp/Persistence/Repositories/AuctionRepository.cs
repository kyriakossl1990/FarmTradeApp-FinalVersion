using FarmTradeApp.Persistence;
using FarmTradeApp.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmTradeApp.Core.Repositories;
using System.Data.Entity;

namespace FarmTradeApp.Persistence.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ApplicationDbContext _context;

        public AuctionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Auction GetExpiredAuction()
        {
            return _context.Auctions
                .Include(a => a.MarketEntries.Select(m => m.User))
                .Include(a => a.MarketEntries.Select(e => e.FinalProduct))
                .Single(a => !a.IsCompleted);
        }

        public Auction GetActiveAuction()
        {
            return _context.Auctions
                .Include(a => a.MarketEntries)
                .FirstOrDefault(a => !a.IsCompleted);
        }

        public Auction GetAuction(int? id)
        {
            return _context.Auctions
                .Include(a => a.MarketEntries)
                .SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Auction> GetYearAuctions(int year)
        {
            return _context.Auctions
                .Where(a => a.AuctionEndDate.Year == year)
                .ToList();
        }

        public void Add(Auction auction)
        {
            _context.Auctions.Add(auction);
        }
    }
}