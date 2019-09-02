namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LandlineNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsVerrified", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "MobileNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MobileNumber", c => c.String());
            DropColumn("dbo.AspNetUsers", "IsVerrified");
            DropColumn("dbo.AspNetUsers", "LandlineNumber");
        }
    }
}
