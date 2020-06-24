namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableTickets1 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Tickets", "TicketActionId", "dbo.TicketActions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
        }
    }
}
