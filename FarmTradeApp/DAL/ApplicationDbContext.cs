using FarmTradeApp.Models;
using FarmTradeApp.Models.Market;
using FarmTradeApp.Models.Notifications;
using FarmTradeApp.Models.Products;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FarmTradeApp.DAL
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
            // Configuring relationship between MarketEntry - TradeMatch
            // Deleting multiple cascade paths
            modelBuilder.Entity<TradeMatch>()
                .HasRequired(t => t.SellerEntry)
                .WithMany()
                .HasForeignKey(t => t.SellerEntryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TradeMatch>()
                .HasRequired(t => t.BuyerEntry)
                .WithMany()
                .HasForeignKey(t => t.BuyerEntryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TradeMatch>()
                .HasRequired(t => t.Auction)
                .WithMany(a => a.TradeMatches)
                .HasForeignKey(t => t.AuctionId)
                .WillCascadeOnDelete(false);

            // Configuring relationship between TradeMatch - TradeSummary
            modelBuilder.Entity<TradeSummary>()
                .HasKey(t => t.TradeMatchId);

            modelBuilder.Entity<TradeMatch>()
                .HasOptional(t => t.TradeSummary)
                .WithRequired(t => t.TradeMatch);
            
            modelBuilder.Entity<UserNotification>()
                .HasRequired(n => n.User)
                .WithMany(u => u.UserNotifications)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}