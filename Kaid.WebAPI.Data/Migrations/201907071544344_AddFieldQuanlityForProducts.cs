namespace Kaid.WebAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldQuanlityForProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quanlity", c => c.Int(nullable: false));
            Sql("UPDATE dbo.products SET Quanlity=1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quanlity");
        }
    }
}
