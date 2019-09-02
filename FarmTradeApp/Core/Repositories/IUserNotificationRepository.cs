using System.Collections.Generic;
using FarmTradeApp.Core.Models.Notifications;

namespace FarmTradeApp.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetUnreadUserNotifications(string userId);
    }
}