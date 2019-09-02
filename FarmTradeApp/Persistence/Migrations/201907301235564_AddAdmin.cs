namespace FarmTradeApp.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                   INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [CompanyName], [LandlineNumber], [Address], [City], [County], [PostCode], [TaxNumber], [DateAccountCreated], [IsBanned], [IsVerrified], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'91f79a62-ff44-4b74-8178-5161ddf09f58', N'admin', N'admin', N'admin', N'2100000000', N'admin', N'admin', N'admin', N'12121', 12121212, CAST(N'2019-07-30T14:58:06.323' AS DateTime), 0, 0, N'admin@bootcamp.gr', 0, N'AFFqZ3T+3AXrVuJ86Q4F9OVEhNLj4X2h36q6ZOVNbxgIY6WXcN7Dmagc10EUMPWZnw==', N'837e94ce-1e03-4052-af17-64b6714716c1', N'6900000000', 0, 0, NULL, 1, 0, N'admin@bootcamp.gr')
                   INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'91f79a62-ff44-4b74-8178-5161ddf09f58', N'568176e5-1a6c-4b50-b559-f13bc39dcb92')
               ");
        }
        
        public override void Down()
        {
        }
    }
}
