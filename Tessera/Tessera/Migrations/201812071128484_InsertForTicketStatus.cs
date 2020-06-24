namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertForTicketStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TicketStatus (Id, Name) VALUES (1, 'Opened') ");
            Sql("INSERT INTO TicketStatus (Id, Name) VALUES (2, 'Redirected') ");
            Sql("INSERT INTO TicketStatus (Id, Name) VALUES (3, 'Service Queue') ");
            Sql("INSERT INTO TicketStatus (Id, Name) VALUES (4, 'In Progress') ");
            Sql("INSERT INTO TicketStatus (Id, Name) VALUES (5, 'Canceled') ");
            Sql("INSERT INTO TicketStatus (Id, Name) VALUES (6, 'Waiting User Information') ");
            Sql("INSERT INTO TicketStatus (Id, Name) VALUES (7, 'Resolved') ");
            Sql("INSERT INTO TicketStatus (Id, Name) VALUES (8, 'Closed') ");
        }
        
        public override void Down()
        {
        }
    }
}
