namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketTable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "PriorityId", c => c.Byte(nullable: false));
            AddColumn("dbo.Tickets", "Priority_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "Priority_Id");
            AddForeignKey("dbo.Tickets", "Priority_Id", "dbo.Priorities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Priority_Id", "dbo.Priorities");
            DropIndex("dbo.Tickets", new[] { "Priority_Id" });
            DropColumn("dbo.Tickets", "Priority_Id");
            DropColumn("dbo.Tickets", "PriorityId");
            DropTable("dbo.Priorities");
        }
    }
}
