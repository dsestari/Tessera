namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableAttachments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attachments", "FileName", c => c.String());
            AddColumn("dbo.Attachments", "Extension", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attachments", "Extension");
            DropColumn("dbo.Attachments", "FileName");
        }
    }
}
