using FarmTradeApp.Models.Market;
using FarmTradeApp.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Dtos
{
    public class NotificationDto
    {
        //Properties
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }

        //Navigation Properties
        public TradeMatchDto TradeMatch { get; private set; }
    }
}