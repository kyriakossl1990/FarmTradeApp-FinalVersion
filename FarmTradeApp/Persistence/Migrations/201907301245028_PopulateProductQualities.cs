namespace FarmTradeApp.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProductQualities : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProductQualities(Id, Grade) VALUES (1, 'A')");
            Sql("INSERT INTO ProductQualities(Id, Grade) VALUES (2, 'B')");
            Sql("INSERT INTO ProductQualities(Id, Grade) VALUES (3, 'C')");
            Sql("INSERT INTO ProductQualities(Id, Grade) VALUES (4, 'D')");
            Sql("INSERT INTO ProductQualities(Id, Grade) VALUES (5, 'E')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM ProductQualities WHERE Id IN (1, 2, 3, 4, 5)");
        }
    }
}
