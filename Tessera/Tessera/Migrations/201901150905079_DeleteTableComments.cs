namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTableComments : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TABLE Comments");
        }
        
        public override void Down()
        {
        }
    }
}
