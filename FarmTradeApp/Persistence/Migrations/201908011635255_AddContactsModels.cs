namespace FarmTradeApp.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactsModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeFormSent = c.DateTime(nullable: false),
                        IsAnswered = c.Boolean(nullable: false),
                        SenderId = c.String(nullable: false, maxLength: 128),
                        ContactFormType = c.Int(nullable: false),
                        Subject = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId);
            
            CreateTable(
                "dbo.PersonalMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Message = c.String(),
                        IsViewed = c.Boolean(nullable: false),
                        TimeSent = c.DateTime(nullable: false),
                        SenderId = c.String(maxLength: 128),
                        ReceiverId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.VerificationForms",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        TimeFormSubmitted = c.DateTime(nullable: false),
                        IsSubmitted = c.Boolean(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VerificationForms", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalMessages", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalMessages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ContactForms", "SenderId", "dbo.AspNetUsers");
            DropIndex("dbo.VerificationForms", new[] { "UserId" });
            DropIndex("dbo.PersonalMessages", new[] { "ReceiverId" });
            DropIndex("dbo.PersonalMessages", new[] { "SenderId" });
            DropIndex("dbo.ContactForms", new[] { "SenderId" });
            DropTable("dbo.VerificationForms");
            DropTable("dbo.PersonalMessages");
            DropTable("dbo.ContactForms");
        }
    }
}
