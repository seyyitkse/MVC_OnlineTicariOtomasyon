namespace MVC_OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargo_details_and_cargo_tracking_page : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 300, unicode: false),
                        TrackingCode = c.String(maxLength: 10, unicode: false),
                        Employee = c.String(maxLength: 20, unicode: false),
                        Customer = c.String(maxLength: 20, unicode: false),
                        DepartureDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        CargoStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailID);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrackingID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 10, unicode: false),
                        TrackingCode = c.String(maxLength: 10, unicode: false),
                        CargoStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
