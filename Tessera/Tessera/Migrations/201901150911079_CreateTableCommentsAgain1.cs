namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCommentsAgain1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.Comments",
            c => new
            {
                Id = c.Int(nullable: false, identity: true),
                CommentText = c.String(nullable: false),
                CreatedDate = c.DateTime(nullable: false),
                TicketId = c.Int(nullable: false),
                UserId = c.Int(nullable: false),
            })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: false)
            .ForeignKey("dbo.Users", u => u.UserId, cascadeDelete: false)
            .Index(u => u.UserId)
            .Index(t => t.TicketId);  
        }
        
        public override void Down()
        {
           
           
        }
    }
}
