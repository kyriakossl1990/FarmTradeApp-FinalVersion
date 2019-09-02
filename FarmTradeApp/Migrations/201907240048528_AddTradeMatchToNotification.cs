namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTradeMatchToNotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "TradeMatch_Id", c => c.Int());
            CreateIndex("dbo.Notifications", "TradeMatch_Id");
            AddForeignKey("dbo.Notifications", "TradeMatch_Id", "dbo.TradeMatches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "TradeMatch_Id", "dbo.TradeMatches");
            DropIndex("dbo.Notifications", new[] { "TradeMatch_Id" });
            DropColumn("dbo.Notifications", "TradeMatch_Id");
        }
    }
}
