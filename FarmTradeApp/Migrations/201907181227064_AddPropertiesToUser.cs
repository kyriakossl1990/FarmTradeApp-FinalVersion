namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MobileNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "County", c => c.String());
            AddColumn("dbo.AspNetUsers", "PostCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "TaxNumber", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DateAccountCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsBanned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsBanned");
            DropColumn("dbo.AspNetUsers", "DateAccountCreated");
            DropColumn("dbo.AspNetUsers", "TaxNumber");
            DropColumn("dbo.AspNetUsers", "PostCode");
            DropColumn("dbo.AspNetUsers", "County");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "MobileNumber");
            DropColumn("dbo.AspNetUsers", "CompanyName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
