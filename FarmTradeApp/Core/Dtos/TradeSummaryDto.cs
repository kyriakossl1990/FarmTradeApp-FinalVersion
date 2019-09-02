using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
{
    public class TradeSummaryDto
    {
        //public int TradeMatchId { get; private set; }

        public bool IsPaid { get; private set; }
        public DateTime? TransactionDate { get; private set; }
        public decimal TransactionAmount { get; private set; }

        public bool IsDelivered { get; private set; }
        public DateTime? DeliveryDate { get; private set; }

        public string Details { get; private set; }

        public bool IsCompleted { get; private set; }

        // Navigation Properties
        public TradeMatchDto TradeMatch { get; private set; }
    }
}