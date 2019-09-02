namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarketEntryAndAuctionModels : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MarketEntries", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MarketEntries", "FinalProductId", "dbo.FinalProducts");
            DropForeignKey("dbo.MarketEntries", "AuctionId", "dbo.Auctions");
            DropIndex("dbo.MarketEntries", new[] { "FinalProductId" });
            DropIndex("dbo.MarketEntries", new[] { "AuctionId" });
            DropIndex("dbo.MarketEntries", new[] { "UserId" });
            DropTable("dbo.MarketEntries");
            DropTable("dbo.Auctions");
        }
    }
}
