namespace VEGAACABLE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryColumnToSupplierTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supliers", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Supliers", "Category");
        }
    }
}
