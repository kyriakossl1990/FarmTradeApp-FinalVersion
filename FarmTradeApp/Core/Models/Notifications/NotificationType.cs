using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Notifications
{
    public enum NotificationType
    {
        TradeMatchCompleted = 1,
        PaymentCompleted = 2,
        DeliveryCompleted = 3,
        TradeSummaryCompleted = 4,
        // Contact Form Notifications
        NewUnreadContactForm = 5,
        UnAnsweredForm = 6,
        // Verification Form Notifications
        NewVerificationForm = 7,
        AcceptedVerificationForm = 8,
        RejectedVerificationForm = 9,
        // Personal Message Notifications
        NewUnreadPm = 10
    }
}