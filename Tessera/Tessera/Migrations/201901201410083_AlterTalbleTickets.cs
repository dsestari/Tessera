namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTalbleTickets : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Tickets", "TicketActionId", c => c.Byte(nullable: false));
            //CreateIndex("dbo.Tickets", "TicketActionId");
            //AddForeignKey("dbo.Tickets", "TicketActionId", "dbo.TicketActions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Tickets", "TicketActionId", "dbo.TicketActions");
            //DropIndex("dbo.Tickets", new[] { "TicketActionId" });
            //DropColumn("dbo.Tickets", "TicketActionId");
        }
    }
}
