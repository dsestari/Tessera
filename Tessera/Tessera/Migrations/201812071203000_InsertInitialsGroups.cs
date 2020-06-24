namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertInitialsGroups : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (1, 'IT Help Desk', 1, GETDATE())");
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (2, 'IT Help Desk L2', 1, GETDATE())");
        }
        
        public override void Down()
        {
        }
    }
}
