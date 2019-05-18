namespace Kaid.WebAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTagsAndPostsTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "Content", c => c.String());
            AddColumn("dbo.Post", "ViewCount", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "ViewCount");
            DropColumn("dbo.Post", "Content");
        }
    }
}
