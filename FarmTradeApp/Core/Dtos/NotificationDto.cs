using FarmTradeApp.Core.Models.Market;
using FarmTradeApp.Core.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Dtos
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