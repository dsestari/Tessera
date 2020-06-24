namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateTableTicketActions : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.TicketActions",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);

            //AddColumn("dbo.Tickets", "TicketActionId", c => c.Int(nullable: false));
            //AddColumn("dbo.Tickets", "TicketActions_Id", c => c.Int());
            //CreateIndex("dbo.Tickets", "TicketActions_Id");
            //AddForeignKey("dbo.Tickets", "TicketActions_Id", "dbo.TicketActions", "Id");
            DropForeignKey("dbo.Tickets", "TicketActions_Id", "dbo.TicketActions");
            DropIndex("dbo.Tickets", new[] { "TicketActions_Id" });
            DropColumn("dbo.Tickets", "TicketActions_Id");
            DropColumn("dbo.Tickets", "TicketActionId");
            DropTable("dbo.TicketActions");

        }

        public override void Down()
        {

        }
    }
}
