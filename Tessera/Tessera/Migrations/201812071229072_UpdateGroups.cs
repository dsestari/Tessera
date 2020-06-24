namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "Initials", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "Initials");
        }
    }
}
