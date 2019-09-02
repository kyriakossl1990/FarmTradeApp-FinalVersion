using FarmTradeApp.Core.Models.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Market
{
    public class TradeSummary
    {
        // * Properties * //
        // Key (FK), configured by fluent api
        public int TradeMatchId { get; private set; }

        public bool IsPaid { get; private set; }
        public DateTime? TransactionDate { get; private set; }
        public decimal TransactionAmount { get; private set; }

        public bool IsDelivered { get; private set; }
        public DateTime? DeliveryDate { get; private set; }

        //[Required]
        public string Details { get; private set; }

        public bool IsCompleted { get; private set; }

        // Navigation Properties
        public TradeMatch TradeMatch { get; private set; }

        // * Constructors * //
        // Default Constructor
        private TradeSummary()
        {}

        // Custom Constructor
        public TradeSummary(int tradeMatchId)
        {
            TradeMatchId = tradeMatchId;
            Details = $"Επιτυχές ματσάρισμα.Αναμένεται διεκπεραίωση πληρωμών";
            TransactionDate = null;
            DeliveryDate = null;
        }

        // * Methods * //
        // Set Transaction Amount
        public void SetTransactionAmount(decimal amount)
        {
            TransactionAmount = amount;
        }

        // Set Paid Status & Transaction Date
        public void SetPayment()
        {
            IsPaid = true;
            TransactionDate = DateTime.Now;
            //notification
            var notification = Notification.TradeSummaryIsPaid(TradeMatch);
            TradeMatch.SellerEntry.User.Notify(notification);
            TradeMatch.BuyerEntry.User.Notify(notification);

            SetDetails();
        }

        // Set Delivery Status & Date
        public void SetDelivery(DateTime deliveryDate)
        {
            IsDelivered = true;
            DeliveryDate = deliveryDate;
            //notification
            var notification = Notification.TradeSummaryIsDelivered(TradeMatch);
            TradeMatch.SellerEntry.User.Notify(notification);
            TradeMatch.BuyerEntry.User.Notify(notification);

            SetDetails();
            SetCompletionStatus();
        }

        // Get Details
        private void SetDetails()
        {
            if (IsPaid)
            {
                if (IsDelivered)
                    Details = "Η παράδοση προιόντος ήταν επιτυχής. Ευχαριστούμε για την συμμετοχή σας!.";
                else
                    Details = "Η πληρωμή της συναλλαγής σας ήταν επιτυχής!";
            }
            else
                Details = $"Επιτυχές ματσάρισμα.Αναμένεται διεκπεραίωση πληρωμών";
        }

        // Get Completion Status
        private void SetCompletionStatus()
        {
            if (IsPaid && IsDelivered)
                IsCompleted = true;
        }
    }
}