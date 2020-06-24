namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertIntoTicketActions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TicketActions VALUES ('Opening ticket')");
            Sql("INSERT INTO TicketActions VALUES ('Redirect')");
            Sql("INSERT INTO TicketActions VALUES ('Stand in line')");
            Sql("INSERT INTO TicketActions VALUES ('Working')");
            Sql("INSERT INTO TicketActions VALUES ('Cancel')");
            Sql("INSERT INTO TicketActions VALUES ('Waiting User Information')");
            Sql("INSERT INTO TicketActions VALUES ('Resolve')");
            Sql("INSERT INTO TicketActions VALUES ('Close')");            
        }
        
        public override void Down()
        {
        }
    }
}
