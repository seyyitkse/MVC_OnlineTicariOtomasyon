namespace MVC_OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_invoice_table_name_corrected : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoinceItems", "Invoince_InvoinceID", "dbo.Invoinces");
            DropIndex("dbo.InvoinceItems", new[] { "Invoince_InvoinceID" });
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceItemID = c.Int(nullable: false, identity: true),
                        InvoiceItemDescription = c.String(maxLength: 100, unicode: false),
                        InvoiceItemPiece = c.Int(nullable: false),
                        InvoiceItemUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceItemAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceItemStatus = c.Boolean(nullable: false),
                        Invoice_InvoiceID = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceItemID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .Index(t => t.Invoice_InvoiceID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceSerial = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        InvoiceSequence = c.String(maxLength: 6, unicode: false),
                        InvoinceDate = c.DateTime(nullable: false),
                        InvoiceTax = c.String(maxLength: 60, unicode: false),
                        InvoiceClock = c.DateTime(nullable: false),
                        InvoiceDeliverer = c.String(maxLength: 30, unicode: false),
                        InvoiceAcceptor = c.String(maxLength: 30, unicode: false),
                        InvoinceStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            DropTable("dbo.InvoinceItems");
            DropTable("dbo.Invoinces");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Invoinces",
                c => new
                    {
                        InvoinceID = c.Int(nullable: false, identity: true),
                        InvoinceSerial = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        InvoinceSequence = c.String(maxLength: 6, unicode: false),
                        InvoinceDate = c.DateTime(nullable: false),
                        InvoinceTax = c.String(maxLength: 60, unicode: false),
                        InvoinceClock = c.DateTime(nullable: false),
                        InvoinceDeliverer = c.String(maxLength: 30, unicode: false),
                        InvoinceAcceptor = c.String(maxLength: 30, unicode: false),
                        InvoinceStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvoinceID);
            
            CreateTable(
                "dbo.InvoinceItems",
                c => new
                    {
                        InvoinceItemID = c.Int(nullable: false, identity: true),
                        InvoinceItemDescription = c.String(maxLength: 100, unicode: false),
                        InvoinceItemPiece = c.Int(nullable: false),
                        InvoinceItemUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoinceItemAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoinceItemStatus = c.Boolean(nullable: false),
                        Invoince_InvoinceID = c.Int(),
                    })
                .PrimaryKey(t => t.InvoinceItemID);
            
            DropForeignKey("dbo.InvoiceItems", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.InvoiceItems", new[] { "Invoice_InvoiceID" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceItems");
            CreateIndex("dbo.InvoinceItems", "Invoince_InvoinceID");
            AddForeignKey("dbo.InvoinceItems", "Invoince_InvoinceID", "dbo.Invoinces", "InvoinceID");
        }
    }
}
