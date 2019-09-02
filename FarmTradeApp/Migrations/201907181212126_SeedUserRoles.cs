namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7500831e-2755-4fe1-b35d-675823924bd1', N'Buyer')
                   INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd4e9ebad-246b-45de-97f6-7d7e3898d7fc', N'Seller')
               ");
        }
        
        public override void Down()
        {
        }
    }
}
