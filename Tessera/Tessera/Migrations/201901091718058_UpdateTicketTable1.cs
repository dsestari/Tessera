namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketTable1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "IsEditMode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "IsEditMode", c => c.Boolean(nullable: false));
        }
    }
}
