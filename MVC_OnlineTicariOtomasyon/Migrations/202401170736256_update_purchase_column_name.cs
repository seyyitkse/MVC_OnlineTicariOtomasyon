namespace MVC_OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_purchase_column_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductPurchase", c => c.String());
            DropColumn("dbo.Products", "ProductPurschase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductPurschase", c => c.String());
            DropColumn("dbo.Products", "ProductPurchase");
        }
    }
}
