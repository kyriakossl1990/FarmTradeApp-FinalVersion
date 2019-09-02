using FarmTradeApp.Core.Models.Notifications;
using FarmTradeApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetUnreadNotifications(string userId)
        {
            return _context.UserNotifications
                     .Where(un => !un.IsRead && un.UserId == userId)
                     .Select(un => un.Notification)
                     .Include(n => n.TradeMatch.SellerEntry.User)
                     .Include(n => n.TradeMatch.BuyerEntry.User)
                     .Include(n => n.TradeMatch.BuyerEntry.FinalProduct.Product)
                     .Include(n => n.TradeMatch.TradeSummary)
                     .ToList();
        }
    }
}