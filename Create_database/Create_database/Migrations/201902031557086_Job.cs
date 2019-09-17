namespace Create_database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Job : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        active = c.Boolean(nullable: false),
                        parentJob_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jobs", t => t.parentJob_id)
                .Index(t => t.parentJob_id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        weight = c.Int(nullable: false),
                        completed = c.Boolean(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                        Job_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jobs", t => t.Job_id)
                .Index(t => t.Job_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Job_id", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "parentJob_id", "dbo.Jobs");
            DropIndex("dbo.Tasks", new[] { "Job_id" });
            DropIndex("dbo.Jobs", new[] { "parentJob_id" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Jobs");
        }
    }
}
