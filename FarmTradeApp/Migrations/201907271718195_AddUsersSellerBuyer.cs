namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersSellerBuyer : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [CompanyName], [LandlineNumber], [Address], [City], [County], [PostCode], [TaxNumber], [DateAccountCreated], [IsBanned]) VALUES (N'797add78-8f41-42b2-bdbc-d5a50d5b985e', N'buyer1@bootcamp.gr', 0, N'AOMN0aflNELfDj48O1lY6ez+fhGPZRk4JwcGBHBt0I0bhEhO+ULsMhzcai13qmduwA==', N'01a98709-6c02-43e4-be26-0ebd78cefce8', N'2101111111', 0, 0, NULL, 1, 0, N'buyer1@bootcamp.gr', N'Κωνσταντίνος', N'Δημητρίου', N'ΣΚΛΑΒΕΝΙΤΗΣ', N'6911111111', N'Λαρισης 17', N'Αθήνα', N'Αθηνών', N'12122', 222222, CAST(N'2019-07-21T23:55:10.873' AS DateTime), 0)
                    INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [CompanyName], [LandlineNumber], [Address], [City], [County], [PostCode], [TaxNumber], [DateAccountCreated], [IsBanned]) VALUES (N'eb24142d-25ac-44ed-9c4d-33a8403c47cc', N'seller1@bootcamp.gr', 0, N'AMxEqF+240naVOMQ7+HbIXLMGhSFqa9V5qwIB4mRz8lGAvtAGsZvG2+wKngtQrTsGA==', N'5c50348e-85af-4c06-9421-fa226d6599d9', N'2100000000', 0, 0, NULL, 1, 0, N'seller1@bootcamp.gr', N'Δημήτρης', N'Νικολάου', NULL, N'6900000000', N'Αδ΄άμαντος 8', N'Λάρισα', N'Λαρίσης', N'11111', 1111111, CAST(N'2019-07-21T23:53:40.420' AS DateTime), 0)
                    INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'797add78-8f41-42b2-bdbc-d5a50d5b985e', N'7500831e-2755-4fe1-b35d-675823924bd1')
                    INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eb24142d-25ac-44ed-9c4d-33a8403c47cc', N'd4e9ebad-246b-45de-97f6-7d7e3898d7fc')
               ");
        }
        
        public override void Down()
        {
        }
    }
}
