namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAdminUserAndRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'568176e5-1a6c-4b50-b559-f13bc39dcb92', N'Administrator')
                   INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3cc10311-ea60-42f0-8c80-fac2273cfc86', N'admin@bootcamp.gr', 0, N'ALd3lrm156qRNecqGYHnC/hZCG2GG07egmszugaZU2JVtmtZvyQyC9j/Q/Wn2XgFlw==', N'32f2d463-ade4-421a-bf79-cd5c73451668', NULL, 0, 0, NULL, 1, 0, N'admin@bootcamp.gr')
                   INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3cc10311-ea60-42f0-8c80-fac2273cfc86', N'568176e5-1a6c-4b50-b559-f13bc39dcb92')
               ");
        }
        
        public override void Down()
        {
        }
    }
}
