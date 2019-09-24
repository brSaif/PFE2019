namespace VEGAACABLE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubjectColumnToTaskTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Subject");
        }
    }
}
