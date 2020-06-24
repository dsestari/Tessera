namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTableTicketActions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "TicketActions_Id", "dbo.TicketActions");
            DropIndex("dbo.Tickets", new[] { "TicketActions_Id" });
            DropColumn("dbo.Tickets", "TicketActionId");
            DropColumn("dbo.Tickets", "TicketActions_Id");
            DropTable("dbo.TicketActions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TicketActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "TicketActions_Id", c => c.Int());
            AddColumn("dbo.Tickets", "TicketActionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "TicketActions_Id");
            AddForeignKey("dbo.Tickets", "TicketActions_Id", "dbo.TicketActions", "Id");
        }
    }
}
