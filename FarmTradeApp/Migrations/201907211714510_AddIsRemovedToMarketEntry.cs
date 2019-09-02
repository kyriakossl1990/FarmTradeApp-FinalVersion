namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsRemovedToMarketEntry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarketEntries", "IsRemoved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarketEntries", "IsRemoved");
        }
    }
}
