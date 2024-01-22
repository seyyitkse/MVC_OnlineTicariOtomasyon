namespace MVC_OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_deliverer_column_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "InvoiceDeliveryEmployee", c => c.String(maxLength: 30, unicode: false));
            DropColumn("dbo.Invoices", "InvoiceDeliverer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "InvoiceDeliverer", c => c.String(maxLength: 30, unicode: false));
            DropColumn("dbo.Invoices", "InvoiceDeliveryEmployee");
        }
    }
}
