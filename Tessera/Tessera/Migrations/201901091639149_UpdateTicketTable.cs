namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "IsEditMode", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "IsEditMode");
        }
    }
}
