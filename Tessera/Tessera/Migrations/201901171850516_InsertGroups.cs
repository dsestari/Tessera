namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGroups : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (3, 'IT Field Support Team', 1, GETDATE())");
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (4, 'IT Systems', 1, GETDATE())");
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (5, 'IT Quality Assurance', 1, GETDATE())");
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (6, 'IT Security Team', 1, GETDATE())");
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (7, 'IT Infrastructure Team', 1, GETDATE())");
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (8, 'IT Business Intelligence', 1, GETDATE())");
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (9, 'IT Data Management', 1, GETDATE())");
            Sql("INSERT INTO Groups (Id, Name, GroupStatusId, CreatedDate) VALUES (10, 'IT Governance', 1, GETDATE())");
        }
        
        public override void Down()
        {
        }
    }
}
