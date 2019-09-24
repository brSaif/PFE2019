namespace VEGAACABLE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReformeTheRelationsWithTask : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupTasks", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.GroupTasks", "GroupId", "dbo.Groups");
            DropIndex("dbo.GroupTasks", new[] { "TaskId" });
            DropIndex("dbo.GroupTasks", new[] { "GroupId" });
            AddColumn("dbo.Groups", "Task_Id", c => c.Int());
            CreateIndex("dbo.Groups", "Task_Id");
            AddForeignKey("dbo.Groups", "Task_Id", "dbo.Tasks", "Id");
            DropTable("dbo.GroupTasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroupTasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TaskId, t.GroupId });
            
            DropForeignKey("dbo.Groups", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.Groups", new[] { "Task_Id" });
            DropColumn("dbo.Groups", "Task_Id");
            CreateIndex("dbo.GroupTasks", "GroupId");
            CreateIndex("dbo.GroupTasks", "TaskId");
            AddForeignKey("dbo.GroupTasks", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GroupTasks", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
        }
    }
}
