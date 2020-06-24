namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertUserStatus1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserStatus (Id, Name) VALUES (3, 'Blocked')");
        }
        
        public override void Down()
        {
        }
    }
}
