namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertUserStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserStatus (Id, Name) VALUES (1, 'Active')");
            Sql("INSERT INTO UserStatus (Id, Name) VALUES (2, 'Inactive')");
        }
        
        public override void Down()
        {
        }
    }
}
