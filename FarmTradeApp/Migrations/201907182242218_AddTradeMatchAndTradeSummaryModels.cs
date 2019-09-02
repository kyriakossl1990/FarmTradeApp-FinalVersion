namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTradeMatchAndTradeSummaryModels : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TradeSummaries", "TradeMatchId", "dbo.TradeMatches");
            DropForeignKey("dbo.TradeMatches", "SellerEntryId", "dbo.MarketEntries");
            DropForeignKey("dbo.TradeMatches", "BuyerEntryId", "dbo.MarketEntries");
            DropForeignKey("dbo.TradeMatches", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.TradeSummaries", new[] { "TradeMatchId" });
            DropIndex("dbo.TradeMatches", new[] { "BuyerEntryId" });
            DropIndex("dbo.TradeMatches", new[] { "SellerEntryId" });
            DropIndex("dbo.TradeMatches", new[] { "AuctionId" });
            DropTable("dbo.TradeSummaries");
            DropTable("dbo.TradeMatches");
        }
    }
}
