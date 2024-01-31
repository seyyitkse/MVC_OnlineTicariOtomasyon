namespace MVC_OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_TodoList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoLists",
                c => new
                    {
                        ToDoID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100, unicode: false),
                        ToDoStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ToDoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TodoLists");
        }
    }
}
