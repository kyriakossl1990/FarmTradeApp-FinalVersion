using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
{
    public class TradeMatchDto
    {
        public int Id { get; private set; }
        public double QuantityExecuted { get; private set; }
        public decimal PriceExecuted { get; private set; }
        public DateTime DateExecuted { get; private set; }

        // Foreign Keys Properties
        public int AuctionId { get; private set; }
        public int SellerEntryId { get; private set; }
        public int BuyerEntryId { get; private set; }

        // Navigation Properties
        public AuctionDto Auction { get; private set; }
        public MarketEntryDto SellerEntry { get; private set; }
        public MarketEntryDto BuyerEntry { get; private set; }
        public TradeSummaryDto TradeSummary { get; private set; }
    }
}