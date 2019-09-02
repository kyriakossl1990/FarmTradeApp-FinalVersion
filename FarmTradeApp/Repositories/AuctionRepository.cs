using FarmTradeApp.DAL;
using FarmTradeApp.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Repositories
{
    public class AuctionRepository
    {
        private readonly ApplicationDbContext _context;

        public AuctionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Auction GetActiveAuction()
        {
            return _context.Auctions.FirstOrDefault(a => !a.IsCompleted);
        }
    }
}