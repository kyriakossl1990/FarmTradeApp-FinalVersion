using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Models.Notifications
{
    public enum NotificationType
    {
        TradeMatchCompleted = 1,
        PaymentCompleted = 2,
        DeliveryCompleted = 3,
        TradeSummaryCompleted = 4,
    }
}