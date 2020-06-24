namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupStatus",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false, maxLength: 10),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UserStatus",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false, maxLength: 10),
                })
                .PrimaryKey(t => t.Id);           
                                    
            CreateTable(
                          "dbo.Groups",
                          c => new
                          {
                              Id = c.Byte(nullable: false),
                              Name = c.String(nullable: false, maxLength: 255),
                              GroupStatusId = c.Byte(nullable: false),
                              CreatedDate = c.DateTime(nullable: false),
                          })
                          .PrimaryKey(t => t.Id)
                          .ForeignKey("dbo.GroupStatus", t => t.GroupStatusId, cascadeDelete: true)
                          .Index(t => t.GroupStatusId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    Email = c.String(nullable: false),
                    Password = c.String(nullable: false),
                    GroupId = c.Byte(nullable: false),
                    UserStatusId = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.UserStatus", t => t.UserStatusId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.UserStatusId);

            CreateTable(
                "dbo.TicketStatus",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false, maxLength: 25),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpeningDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        UpdateIn = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 255),
                        UserMail = c.String(),
                        UserPhone = c.String(),
                        Address = c.String(),
                        Summary = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        TicketStatusId = c.Byte(nullable: false),
                        GroupId = c.Byte(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)                
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.TicketStatus", t => t.TicketStatusId, cascadeDelete: true)                
                .Index(t => t.GroupId)
                .Index(t => t.UserId)
                .Index(t => t.TicketStatusId);

            CreateTable(
                "dbo.Comments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CommentText = c.String(nullable: false),
                    CreatedDate = c.DateTime(nullable: false),
                    TicketId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
        }

        public override void Down()
        {
            //DropForeignKey("dbo.Groups", "GroupStatusId", "dbo.GroupStatus");
            //DropForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus");
            //DropForeignKey("dbo.Users", "GroupId", "dbo.Groups");
            //DropForeignKey("dbo.Tickets", "TicketStatusId", "dbo.TicketStatus");
            //DropForeignKey("dbo.Tickets", "GroupId", "dbo.Groups");
            //DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            //DropForeignKey("dbo.Comments", "TicketId", "dbo.Tickets");                  
                        
            //DropIndex("dbo.Users", new[] { "UserStatusId" });
            //DropIndex("dbo.Groups", new[] { "GroupStatusId" });
            //DropIndex("dbo.Users", new[] { "GroupId" });
            //DropIndex("dbo.Tickets", new[] { "TicketStatusId" });
            //DropIndex("dbo.Tickets", new[] { "UserId" });
            //DropIndex("dbo.Tickets", new[] { "GroupId" });            
            //DropIndex("dbo.Comments", new[] { "TicketId" });

            //DropTable("dbo.GroupStatus");
            //DropTable("dbo.UserStatus");
            //DropTable("dbo.Groups");
            //DropTable("dbo.Users");
            //DropTable("dbo.TicketStatus");         
            //DropTable("dbo.Tickets");
            //DropTable("dbo.Comments");
        }
    }
}
