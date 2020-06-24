namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGroupStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GroupStatus (Id, Name) VALUES (1, 'Active')");
            Sql("INSERT INTO GroupStatus (Id, Name) VALUES (2, 'Inactive')");
        }
        
        public override void Down()
        {
        }
    }
}
