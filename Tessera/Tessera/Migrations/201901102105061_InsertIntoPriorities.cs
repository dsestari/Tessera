namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertIntoPriorities : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Priorities (Name) VALUES ('Low')");
            Sql("INSERT INTO Priorities (Name) VALUES ('Normal')");
            Sql("INSERT INTO Priorities (Name) VALUES ('High')");
            Sql("INSERT INTO Priorities (Name) VALUES ('Urgent')");
            Sql("INSERT INTO Priorities (Name) VALUES ('Critical')");

        }
        
        public override void Down()
        {
        }
    }
}
