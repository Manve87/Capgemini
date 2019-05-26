namespace Capgemini.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        taskName = c.String(maxLength: 255),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id);

           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "user_id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "user_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
