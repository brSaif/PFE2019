namespace VEGAACABLE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupMessages", "MassegeId", "dbo.Messages");
            DropForeignKey("dbo.GroupMessages", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserMessages", "MessageId", "dbo.Messages");
            DropForeignKey("dbo.UserMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Groups", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.Groups", new[] { "Task_Id" });
            DropIndex("dbo.UserMessages", new[] { "UserId" });
            DropIndex("dbo.UserMessages", new[] { "MessageId" });
            DropIndex("dbo.GroupMessages", new[] { "MassegeId" });
            DropIndex("dbo.GroupMessages", new[] { "GroupId" });
            DropColumn("dbo.Groups", "Task_Id");
            DropTable("dbo.Messages");
            DropTable("dbo.UserMessages");
            DropTable("dbo.Tasks");
            DropTable("dbo.GroupMessages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroupMessages",
                c => new
                    {
                        MassegeId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MassegeId, t.GroupId });
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(nullable: false, maxLength: 200, unicode: false),
                        Deadline = c.DateTime(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        ViewedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        MessageId = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 60, unicode: false),
                        Content = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Groups", "Task_Id", c => c.Int());
            CreateIndex("dbo.GroupMessages", "GroupId");
            CreateIndex("dbo.GroupMessages", "MassegeId");
            CreateIndex("dbo.UserMessages", "MessageId");
            CreateIndex("dbo.UserMessages", "UserId");
            CreateIndex("dbo.Groups", "Task_Id");
            AddForeignKey("dbo.Groups", "Task_Id", "dbo.Tasks", "Id");
            AddForeignKey("dbo.UserMessages", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserMessages", "MessageId", "dbo.Messages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GroupMessages", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GroupMessages", "MassegeId", "dbo.Messages", "Id", cascadeDelete: true);
        }
    }
}
