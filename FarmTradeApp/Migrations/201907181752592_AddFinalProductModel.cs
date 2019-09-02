namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinalProductModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinalProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImportDateToStorage = c.DateTime(),
                        ExportDateFromStorage = c.DateTime(),
                        IsOrganic = c.Boolean(nullable: false),
                        Comments = c.String(),
                        Quantity = c.Int(),
                        ProductId = c.Int(nullable: false),
                        QualityId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        LocationId = c.Int(),
                        StorageId = c.Int(),
                        Quality_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductQualities", t => t.Quality_Id)
                .ForeignKey("dbo.Storages", t => t.StorageId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UserId)
                .Index(t => t.LocationId)
                .Index(t => t.StorageId)
                .Index(t => t.Quality_Id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinalProducts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FinalProducts", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.FinalProducts", "Quality_Id", "dbo.ProductQualities");
            DropForeignKey("dbo.FinalProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.FinalProducts", "LocationId", "dbo.Locations");
            DropIndex("dbo.FinalProducts", new[] { "Quality_Id" });
            DropIndex("dbo.FinalProducts", new[] { "StorageId" });
            DropIndex("dbo.FinalProducts", new[] { "LocationId" });
            DropIndex("dbo.FinalProducts", new[] { "UserId" });
            DropIndex("dbo.FinalProducts", new[] { "ProductId" });
            DropTable("dbo.FinalProducts");
        }
    }
}
