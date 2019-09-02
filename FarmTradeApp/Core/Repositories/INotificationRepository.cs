using System.Collections.Generic;
using FarmTradeApp.Core.Models.Notifications;

namespace FarmTradeApp.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetUnreadNotifications(string userId);
    }
}