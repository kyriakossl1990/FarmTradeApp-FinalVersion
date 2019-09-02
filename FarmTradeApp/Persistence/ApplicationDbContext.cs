using FarmTradeApp.Core.Models;
using FarmTradeApp.Core.Models.Contacts;
using FarmTradeApp.Core.Models.Market;
using FarmTradeApp.Core.Models.Notifications;
using FarmTradeApp.Core.Models.Products;
using FarmTradeApp.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FarmTradeApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductQuality> ProductQualities { get; set; }
        public DbSet<FinalProduct> FinalProducts { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<MarketEntry> MarketEntries { get; set; }
        public DbSet<TradeMatch> TradeMatches { get; set; }
        public DbSet<TradeSummary> TradeSummaries { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<VerificationForm> VerificationForms { get; set; }
        public DbSet<PersonalMessage> PersonalMessages { get; set; }

        public ApplicationDbContext()
            : base("FarmTradeContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TradeMatchConfiguration());
            modelBuilder.Configurations.Add(new TradeSummaryConfiguration());
            modelBuilder.Configurations.Add(new UserNotificationConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new VerificationFormConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}