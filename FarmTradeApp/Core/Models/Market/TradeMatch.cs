using FarmTradeApp.Core.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Market
{
    public class TradeMatch
    {
        // * Properties * //
        public int Id { get; private set; }
        public double QuantityExecuted { get; private set; }
        public decimal PriceExecuted { get; private set; }
        public DateTime DateExecuted { get; private set; }

        // Foreign Keys Properties
        public int AuctionId { get; private set; }
        public int SellerEntryId { get; private set; }
        public int BuyerEntryId { get; private set; }

        // Navigation Properties
        public Auction Auction { get; private set; }
        public MarketEntry SellerEntry { get; private set; }
        public MarketEntry BuyerEntry { get; private set; }
        public TradeSummary TradeSummary { get; private set; }

        //create this nav prop for notification usage
        

        // * Constructors * //
        // Default Constructor
        private TradeMatch()
        {}

        // Custom Constructor
        public TradeMatch(int auctionId, int sellerEntryId, int buyerEntryId,
                          double quantityExecuted, decimal priceExecuted)
        {
            AuctionId = auctionId;
            SellerEntryId = sellerEntryId;
            BuyerEntryId = buyerEntryId;
            QuantityExecuted = quantityExecuted;
            PriceExecuted = priceExecuted;
            DateExecuted = DateTime.Now;
       
        }

        public void SetTradeSummary()
        {
            TradeSummary = new TradeSummary(Id);
            decimal transactionAmount = PriceExecuted * (decimal)QuantityExecuted;
        
            TradeSummary.SetTransactionAmount(transactionAmount);
        }

        
    }
}