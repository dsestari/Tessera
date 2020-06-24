namespace Tessera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CommentText", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Comments", "CommentText", c => c.String(nullable: false, storeType: "ntext"));
        }
    }
}
