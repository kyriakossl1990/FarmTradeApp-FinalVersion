using FarmTradeApp.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Notifications
{
    public class Notification
    {
        //Properties
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }

        //Navigation Properties
        public TradeMatch TradeMatch { get; set; }

        //default constructor
        private Notification() { }
       
        //custom constructor
        private Notification(NotificationType type, TradeMatch tradeMatch)
        {
            if (tradeMatch == null)
               throw new ArgumentNullException("tradeSummary");
            Type = type;
            TradeMatch = tradeMatch;
            DateTime = DateTime.Now;          
        }

        //Static factory methods
        public static Notification TradeMatchCompleted(TradeMatch tradeMatch)
        {
            
            return new Notification(NotificationType.TradeMatchCompleted, tradeMatch);
        }

        public static Notification TradeSummaryIsPaid(TradeMatch tradeMatch)
        {

            return new Notification(NotificationType.PaymentCompleted, tradeMatch);
        }

        public static Notification TradeSummaryIsDelivered(TradeMatch tradeMatch)
        {

            return new Notification(NotificationType.DeliveryCompleted, tradeMatch);
        }

        public static Notification TradeSummaryCompleted(TradeMatch tradeMatch)
        {

            return new Notification(NotificationType.TradeSummaryCompleted, tradeMatch);
        }
    }
}