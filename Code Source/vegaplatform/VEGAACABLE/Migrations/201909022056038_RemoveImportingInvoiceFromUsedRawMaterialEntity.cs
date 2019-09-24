namespace VEGAACABLE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImportingInvoiceFromUsedRawMaterialEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImportingInvoices", "UsedRawMaterial_Id", "dbo.UsedRawMaterials");
            DropIndex("dbo.ImportingInvoices", new[] { "UsedRawMaterial_Id" });
            DropColumn("dbo.ImportingInvoices", "UsedRawMaterial_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImportingInvoices", "UsedRawMaterial_Id", c => c.Int());
            CreateIndex("dbo.ImportingInvoices", "UsedRawMaterial_Id");
            AddForeignKey("dbo.ImportingInvoices", "UsedRawMaterial_Id", "dbo.UsedRawMaterials", "Id");
        }
    }
}
