namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTradeSummaryFromNotification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "TradeSummary_TradeMatchId", "dbo.TradeSummaries");
            DropIndex("dbo.Notifications", new[] { "TradeSummary_TradeMatchId" });
            DropColumn("dbo.Notifications", "TradeSummary_TradeMatchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "TradeSummary_TradeMatchId", c => c.Int());
            CreateIndex("dbo.Notifications", "TradeSummary_TradeMatchId");
            AddForeignKey("dbo.Notifications", "TradeSummary_TradeMatchId", "dbo.TradeSummaries", "TradeMatchId");
        }
    }
}
