namespace FarmTradeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationStorageChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Storages", "Street", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Storages", "Street");
        }
    }
}
