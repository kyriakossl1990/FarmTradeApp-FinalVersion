namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductCategoryAndQualityFKTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FinalProducts", "Quality_Id", "dbo.ProductQualities");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories");
            DropIndex("dbo.FinalProducts", new[] { "Quality_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropColumn("dbo.FinalProducts", "QualityId");
            DropColumn("dbo.Products", "CategoryId");
            RenameColumn(table: "dbo.FinalProducts", name: "Quality_Id", newName: "QualityId");
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.FinalProducts", "QualityId", c => c.Byte(nullable: false));
            AlterColumn("dbo.FinalProducts", "QualityId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Short(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Short(nullable: false));
            CreateIndex("dbo.FinalProducts", "QualityId");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.FinalProducts", "QualityId", "dbo.ProductQualities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.ProductCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.FinalProducts", "QualityId", "dbo.ProductQualities");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.FinalProducts", new[] { "QualityId" });
            AlterColumn("dbo.Products", "CategoryId", c => c.Short());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.FinalProducts", "QualityId", c => c.Byte());
            AlterColumn("dbo.FinalProducts", "QualityId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
            RenameColumn(table: "dbo.FinalProducts", name: "QualityId", newName: "Quality_Id");
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.FinalProducts", "QualityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.FinalProducts", "Quality_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories", "Id");
            AddForeignKey("dbo.FinalProducts", "Quality_Id", "dbo.ProductQualities", "Id");
        }
    }
}
