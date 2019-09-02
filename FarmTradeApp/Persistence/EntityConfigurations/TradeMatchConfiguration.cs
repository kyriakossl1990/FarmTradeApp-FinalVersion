using FarmTradeApp.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Persistence.EntityConfigurations
{
    public class TradeMatchConfiguration : EntityTypeConfiguration<TradeMatch>
    {
        public TradeMatchConfiguration()
        {
            // Configuring relationship between MarketEntry - TradeMatch
            // Deleting multiple cascade paths
             HasRequired(t => t.SellerEntry)
                .WithMany()
                .HasForeignKey(t => t.SellerEntryId)
                .WillCascadeOnDelete(false);

             HasRequired(t => t.BuyerEntry)
                .WithMany()
                .HasForeignKey(t => t.BuyerEntryId)
                .WillCascadeOnDelete(false);

             HasRequired(t => t.Auction)
                .WithMany(a => a.TradeMatches)
                .HasForeignKey(t => t.AuctionId)
                .WillCascadeOnDelete(false);

            // Configuring relationship between TradeMatch - TradeSummary
            HasOptional(t => t.TradeSummary)
                .WithRequired(t => t.TradeMatch);

        }
    }
}