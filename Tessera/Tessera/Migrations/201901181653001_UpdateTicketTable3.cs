namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketTable3 : DbMigration
    {
        public override void Up()
        {
            //Sql("ALTER TABLE dbo.Tickets DROP CONSTRAINT FK_dbo.Tickets_dbo.Priorities_Priority_Id");
            //Sql("ALTER TABLE dbo.Tickets DROP COLUMN Priority_Id");
        }
        
        public override void Down()
        {
        }
    }
}
