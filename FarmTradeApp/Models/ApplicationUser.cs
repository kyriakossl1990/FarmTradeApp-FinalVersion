using FarmTradeApp.Models.Notifications;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace FarmTradeApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // Names
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string CompanyName { get; set; }

        // Contact
        public string LandlineNumber { get; set; }

        // Location
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        // Other
        public int TaxNumber { get; set; }

        // Info for Admin
        public DateTime DateAccountCreated { get; set; }
        public bool IsBanned { get; set; }
        public bool IsVerrified { get; set; }

        //Navigation Properties
        public  ICollection<UserNotification> UserNotifications { get; set; }

        //default constructor
        public ApplicationUser()
        {
            UserNotifications = new Collection<UserNotification>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public void Notify(Notification notification)
        {
            UserNotifications.Add(new UserNotification(this, notification));
        }
    }
}