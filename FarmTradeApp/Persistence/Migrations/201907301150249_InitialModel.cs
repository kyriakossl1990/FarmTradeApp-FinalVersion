namespace FarmTradeApp.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuctionEndDate = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MarketEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsRemoved = c.Boolean(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        EntryType = c.Int(nullable: false),
                        EntryQuantity = c.Double(nullable: false),
                        EntryPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryLocation = c.String(),
                        UserId = c.String(maxLength: 128),
                        AuctionId = c.Int(nullable: false),
                        FinalProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId, cascadeDelete: true)
                .ForeignKey("dbo.FinalProducts", t => t.FinalProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AuctionId)
                .Index(t => t.FinalProductId);
            
            CreateTable(
                "dbo.FinalProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImportDateToStorage = c.DateTime(),
                        ExportDateFromStorage = c.DateTime(),
                        IsOrganic = c.Boolean(nullable: false),
                        Comments = c.String(),
                        Quantity = c.Int(),
                        ProductId = c.Int(nullable: false),
                        QualityId = c.Byte(nullable: false),
                        UserId = c.String(maxLength: 128),
                        LocationId = c.Int(),
                        StorageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductQualities", t => t.QualityId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.QualityId)
                .Index(t => t.UserId)
                .Index(t => t.LocationId)
                .Index(t => t.StorageId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductQualities",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Street = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CompanyName = c.String(),
                        LandlineNumber = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        County = c.String(),
                        PostCode = c.String(),
                        TaxNumber = c.Int(nullable: false),
                        DateAccountCreated = c.DateTime(nullable: false),
                        IsBanned = c.Boolean(nullable: false),
                        IsVerrified = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        TradeMatch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TradeMatches", t => t.TradeMatch_Id)
                .Index(t => t.TradeMatch_Id);
            
            CreateTable(
                "dbo.TradeMatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantityExecuted = c.Double(nullable: false),
                        PriceExecuted = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateExecuted = c.DateTime(nullable: false),
                        AuctionId = c.Int(nullable: false),
                        SellerEntryId = c.Int(nullable: false),
                        BuyerEntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auctions", t => t.AuctionId)
                .ForeignKey("dbo.MarketEntries", t => t.BuyerEntryId)
                .ForeignKey("dbo.MarketEntries", t => t.SellerEntryId)
                .Index(t => t.AuctionId)
                .Index(t => t.SellerEntryId)
                .Index(t => t.BuyerEntryId);
            
            CreateTable(
                "dbo.TradeSummaries",
                c => new
                    {
                        TradeMatchId = c.Int(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        TransactionDate = c.DateTime(),
                        TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelivered = c.Boolean(nullable: false),
                        DeliveryDate = c.DateTime(),
                        Details = c.String(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TradeMatchId)
                .ForeignKey("dbo.TradeMatches", t => t.TradeMatchId)
                .Index(t => t.TradeMatchId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MarketEntries", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MarketEntries", "FinalProductId", "dbo.FinalProducts");
            DropForeignKey("dbo.FinalProducts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "TradeMatch_Id", "dbo.TradeMatches");
            DropForeignKey("dbo.TradeSummaries", "TradeMatchId", "dbo.TradeMatches");
            DropForeignKey("dbo.TradeMatches", "SellerEntryId", "dbo.MarketEntries");
            DropForeignKey("dbo.TradeMatches", "BuyerEntryId", "dbo.MarketEntries");
            DropForeignKey("dbo.TradeMatches", "AuctionId", "dbo.Auctions");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Storages", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.FinalProducts", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.FinalProducts", "QualityId", "dbo.ProductQualities");
            DropForeignKey("dbo.FinalProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.FinalProducts", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.MarketEntries", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TradeSummaries", new[] { "TradeMatchId" });
            DropIndex("dbo.TradeMatches", new[] { "BuyerEntryId" });
            DropIndex("dbo.TradeMatches", new[] { "SellerEntryId" });
            DropIndex("dbo.TradeMatches", new[] { "AuctionId" });
            DropIndex("dbo.Notifications", new[] { "TradeMatch_Id" });
            DropIndex("dbo.UserNotifications", new[] { "NotificationId" });
            DropIndex("dbo.UserNotifications", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Storages", new[] { "LocationId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.FinalProducts", new[] { "StorageId" });
            DropIndex("dbo.FinalProducts", new[] { "LocationId" });
            DropIndex("dbo.FinalProducts", new[] { "UserId" });
            DropIndex("dbo.FinalProducts", new[] { "QualityId" });
            DropIndex("dbo.FinalProducts", new[] { "ProductId" });
            DropIndex("dbo.MarketEntries", new[] { "FinalProductId" });
            DropIndex("dbo.MarketEntries", new[] { "AuctionId" });
            DropIndex("dbo.MarketEntries", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TradeSummaries");
            DropTable("dbo.TradeMatches");
            DropTable("dbo.Notifications");
            DropTable("dbo.UserNotifications");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Storages");
            DropTable("dbo.ProductQualities");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Locations");
            DropTable("dbo.FinalProducts");
            DropTable("dbo.MarketEntries");
            DropTable("dbo.Auctions");
        }
    }
}
