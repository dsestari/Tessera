namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableComments1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "TicketId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Comments", "TicketId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
        }
    }
}
