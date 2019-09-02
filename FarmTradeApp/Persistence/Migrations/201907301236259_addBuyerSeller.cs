namespace FarmTradeApp.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBuyerSeller : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [CompanyName], [LandlineNumber], [Address], [City], [County], [PostCode], [TaxNumber], [DateAccountCreated], [IsBanned], [IsVerrified], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'33fe5b7d-40af-4f31-ac64-65b6e9c95859', N'Δημήτριος', N'Νικολάου', NULL, N'121212', N'address', N'address', N'address', N'121212', 121212, CAST(N'2019-07-30T15:39:15.790' AS DateTime), 0, 0, N'seller1@bootcamp.gr', 0, N'AH8vd4cYrEgH+U3uglGysVuWTtbJ1sZ/ZudJaT6lfCGUd9sG4EA2KBoQn0lE4m5NpA==', N'f54d574f-961e-4f13-99b4-7742a427dc03', N'121212', 0, 0, NULL, 1, 0, N'seller1@bootcamp.gr')
                    INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [CompanyName], [LandlineNumber], [Address], [City], [County], [PostCode], [TaxNumber], [DateAccountCreated], [IsBanned], [IsVerrified], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e5ca3a2d-94b0-4e99-aa3d-0f889f2c0cef', N'Κωστας', N'Πετρου', N'ΣΚΛΑΒΕΝΙΤΗΣ', N'121212', N'address', N'address', N'address', N'121212', 121212, CAST(N'2019-07-30T15:40:27.760' AS DateTime), 0, 0, N'buyer1@bootcamp.gr', 0, N'ANdn8rHuuuZf5nug21ZmG/gAwM6mrQp4bwLl7SuUetI7tQtV/Qc47Gg7gNbGIbLdEw==', N'ae5e4a10-04aa-4d5b-8db8-1e8db60861b1', N'121212', 0, 0, NULL, 1, 0, N'buyer1@bootcamp.gr')
                    INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e5ca3a2d-94b0-4e99-aa3d-0f889f2c0cef', N'7500831e-2755-4fe1-b35d-675823924bd1')
                    INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33fe5b7d-40af-4f31-ac64-65b6e9c95859', N'd4e9ebad-246b-45de-97f6-7d7e3898d7fc')
               ");
        }
        
        public override void Down()
        {
        }
    }
}
