namespace MVC_OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_departmentstatus_data_type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "DepartmentStatus", c => c.String());
        }
    }
}
