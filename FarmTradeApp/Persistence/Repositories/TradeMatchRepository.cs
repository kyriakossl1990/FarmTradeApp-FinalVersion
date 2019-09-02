using FarmTradeApp.Core.Models.Market;
using FarmTradeApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FarmTradeApp.Persistence.Repositories
{
    public class TradeMatchRepository : ITradeMatchRepository
    {
        private readonly ApplicationDbContext _context;

        public TradeMatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TradeMatch> GetUserTradeMatches()
        {
            return _context.TradeMatches
                .Include(tm => tm.Auction)
                .Include(tm => tm.BuyerEntry.FinalProduct.Quality)
                .Include(tm => tm.BuyerEntry.FinalProduct.Product)
                .Include(tm => tm.BuyerEntry.User)
                .Include(tm => tm.SellerEntry.User)
                .Include(tm => tm.TradeSummary)
                .ToList();
        }
    }
}