using FarmTradeApp.Core.Models.Market;
using System.Collections.Generic;

namespace FarmTradeApp.Core.Repositories
{
    public interface IAuctionRepository
    {
        Auction GetExpiredAuction();
        Auction GetActiveAuction();
        Auction GetAuction(int? id);
        IEnumerable<Auction> GetYearAuctions(int year);
        void Add(Auction auction);
    }
}