using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Core.Models.Notifications
{
    public class UserNotification
    {
        //Properties
        [Key]
        [Column(Order = 1)]
        public string UserId { get; private set; }
        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }

        public bool IsRead { get; set; }

        //Navigation Properties
        public Notification Notification { get; private set; }

        public ApplicationUser User { get; private set; }

        //Default constructor required from EF
        private UserNotification() { }
        
        //Custom constructor
        public UserNotification(ApplicationUser user,Notification notification)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (notification == null)
                throw new ArgumentNullException("notification");
            User = user;
            Notification = notification;
            
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}