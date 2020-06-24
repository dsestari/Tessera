namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "VCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "VCode");
        }
    }
}
