namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablePriorities : DbMigration
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

            AddColumn("dbo.Tickets", "PriorityId", c => c.Int(nullable: false));        
           
            AddForeignKey("dbo.Tickets", "PriorityId", "dbo.Priorities", "Id");
        }
        
        public override void Down()
        {
        }
    }
}
