namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTablePriority : DbMigration
    {
        public override void Up()
        {
          Sql("Alter Table dbo.Tickets Drop Column Priority_Id");
        }
        
        public override void Down()
        {
        }
    }
}
