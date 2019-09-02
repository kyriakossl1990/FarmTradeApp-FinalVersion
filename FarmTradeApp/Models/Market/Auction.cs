using FarmTradeApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.Timers;
using FarmTradeApp.ViewModels;
using FarmTradeApp.Models.Notifications;

namespace FarmTradeApp.Models.Market
{
    public class Auction
    {
        // * Properties * //
        public int Id { get; private set; }
        public DateTime AuctionEndDate { get; private set; }
        public bool IsCompleted { get; private set; }

        // Navigation Properties
        public ICollection<MarketEntry> MarketEntries { get; private set; }
        public ICollection<TradeMatch> TradeMatches { get; private set; }

        // * Constructors * //
        // Default Constructor
        private Auction()
        {
            MarketEntries = new Collection<MarketEntry>();
            TradeMatches = new Collection<TradeMatch>();
        }

        // * Methods * //
        // Static Factory Method - Initialize New Auction
        public static Auction Initialize(DateTime previousAuctionEndDate)
        {
            var newAuction = new Auction();
            newAuction.SetAuctionEndDate(previousAuctionEndDate);

            return newAuction;
        }

        // Set Auction End Date
        private void SetAuctionEndDate(DateTime previousAuctionEndDate)
        {
            AuctionEndDate = previousAuctionEndDate.AddDays(1);
        }

        // Finalise Expired Auction
        public void Complete()
        {
            IsCompleted = true;
            SetTradeMatches();
            TradeMatches.ToList().ForEach(tm => tm.SetTradeSummary());
        }

        // Algorithm matching Orders
        private void SetTradeMatches()
        {
            var sellerEntries = MarketEntries
                .Where(m => m.EntryType == EntryType.Supply)
                .OrderBy(e => e.EntryDate)
                .ThenBy(e => e.EntryPrice);
            var buyerEntries = MarketEntries
                .Where(m => m.EntryType == EntryType.Demand)
                .OrderBy(e => e.EntryDate)
                .ThenBy(e => e.EntryPrice);

            sellerEntries.ToList().ForEach(se => se.SetMatchQuantity(se.EntryQuantity));
            buyerEntries.ToList().ForEach(be => be.SetMatchQuantity(be.EntryQuantity));

            foreach (var sellerEntry in sellerEntries)
            {
                foreach (var buyerEntry in buyerEntries)
                {
                    if (sellerEntry.FinalProduct.ProductId == buyerEntry.FinalProduct.ProductId &&
                        sellerEntry.FinalProduct.QualityId == buyerEntry.FinalProduct.QualityId &&
                        sellerEntry.DeliveryDate == buyerEntry.DeliveryDate &&
                        sellerEntry.EntryPrice <= buyerEntry.EntryPrice) // price logic Todo
                    {
                        if (sellerEntry.MatchQuantity < buyerEntry.MatchQuantity)
                        {
                            var tradeMatch = new TradeMatch(Id, sellerEntry.Id, buyerEntry.Id,
                                       sellerEntry.MatchQuantity, buyerEntry.EntryPrice);

                            TradeMatches.Add(tradeMatch);

                            //Create the notification
                            var notification = Notification.TradeMatchCompleted(tradeMatch);

                            sellerEntry.User.Notify(notification);

                            buyerEntry.User.Notify(notification);

                            buyerEntry.SetMatchQuantity(buyerEntry.MatchQuantity - tradeMatch.QuantityExecuted);
                            sellerEntry.SetMatchQuantity(sellerEntry.MatchQuantity - tradeMatch.QuantityExecuted);
                        }
                        else
                        {
                            var tradeMatch = new TradeMatch(Id, sellerEntry.Id, buyerEntry.Id,
                                       buyerEntry.MatchQuantity, buyerEntry.EntryPrice);

                            TradeMatches.Add(tradeMatch);

                            //Create the notification
                            var notification = Notification.TradeMatchCompleted(tradeMatch);

                            sellerEntry.User.Notify(notification);

                            buyerEntry.User.Notify(notification);

                            buyerEntry.SetMatchQuantity(buyerEntry.MatchQuantity - tradeMatch.QuantityExecuted);
                            sellerEntry.SetMatchQuantity(sellerEntry.MatchQuantity - tradeMatch.QuantityExecuted);
                        }
                    }
                }
            }
        }

        // Add New Buyer Market Entry to Auction
        public void AddBuyerMarketEntry(MarketEntryFormViewModel viewModel, string userId)
        {
            var marketEntry = MarketEntry.CreateBuyerEntry(userId, EntryType.Demand,
                    Id, viewModel.ProductId, viewModel.ProductQualityId,
                    viewModel.EntryQuantity, viewModel.EntryPrice, viewModel.DeliveryDate,
                    viewModel.DeliveryLocation);
         
            MarketEntries.Add(marketEntry);
        }

        // Add New Seller Market Entry to Auction
        public void AddSellerMarketEntry(MarketEntryFormViewModel viewModel, string userId)
        {
            var marketEntry = MarketEntry.CreateSellerEntry(userId, EntryType.Supply,
                   Id, viewModel.FinalProductId, viewModel.EntryQuantity, 
                   viewModel.EntryPrice, viewModel.DeliveryDate);
     
            MarketEntries.Add(marketEntry);
        }
    }
}