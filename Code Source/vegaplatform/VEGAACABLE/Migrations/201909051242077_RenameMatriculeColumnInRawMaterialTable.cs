namespace VEGAACABLE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMatriculeColumnInRawMaterialTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RawMaterials", "RefNbr", c => c.String(nullable: false));
            DropColumn("dbo.RawMaterials", "Matricule");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RawMaterials", "Matricule", c => c.String(nullable: false));
            DropColumn("dbo.RawMaterials", "RefNbr");
        }
    }
}
