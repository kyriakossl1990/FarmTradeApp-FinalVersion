using System.Collections.Generic;
using FarmTradeApp.Core.Models.Market;

namespace FarmTradeApp.Core.Repositories
{
    public interface IMarketEntryRepository
    {
        MarketEntry GetMarketEntry(int marketEntryId);
        MarketEntry GetMarketEntryWithFinalProduct(int marketEntryId);
        MarketEntry GetMarketEntryWithFinalProductAndAuction(int? marketEntryId);
        MarketEntry GetFullMarketEntry(int marketEntryId);
        IEnumerable<MarketEntry> GetUserMarketEntriesWithFinalProduct();
        void Add(MarketEntry marketEntry);
    }
}