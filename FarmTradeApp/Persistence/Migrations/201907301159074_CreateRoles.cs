namespace FarmTradeApp.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'568176e5-1a6c-4b50-b559-f13bc39dcb92', N'Administrator')
                   INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7500831e-2755-4fe1-b35d-675823924bd1', N'Buyer')
                   INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd4e9ebad-246b-45de-97f6-7d7e3898d7fc', N'Seller')
               ");
        }
        
        public override void Down()
        {
        }
    }
}
