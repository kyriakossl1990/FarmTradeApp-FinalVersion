using FarmTradeApp.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Persistence.EntityConfigurations
{
    public class TradeSummaryConfiguration : EntityTypeConfiguration<TradeSummary>
    {
        public TradeSummaryConfiguration()
        {
            Property(ts => ts.Details)
            .IsRequired();

            // Configuring relationship between TradeMatch - TradeSummary
            HasKey(t => t.TradeMatchId);
        }
    }
}