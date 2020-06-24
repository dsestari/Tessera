namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGroupDatas : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Groups SET Initials = 'ITHD' WHERE Id = 1");
            Sql("UPDATE Groups SET Initials = 'ITHD2' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
