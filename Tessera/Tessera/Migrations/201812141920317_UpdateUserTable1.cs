namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTable1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "VCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "VCode", c => c.String());
        }
    }
}
