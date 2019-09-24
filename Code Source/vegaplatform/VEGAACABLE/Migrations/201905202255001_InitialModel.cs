namespace VEGAACABLE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 50, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 25, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 25, unicode: false),
                        Email = c.String(nullable: false, maxLength: 80, unicode: false),
                        Phone = c.Int(nullable: false),
                        Adress = c.String(nullable: false, maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SellingInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FabOrdId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        PaymentStatus = c.Byte(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.FabricationOrders", t => t.FabOrdId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.FabOrdId)
                .Index(t => t.ClientId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FabricationOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomenclatureId = c.Int(nullable: false),
                        Length = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        StartingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nomenclatures", t => t.NomenclatureId, cascadeDelete: true)
                .Index(t => t.NomenclatureId);
            
            CreateTable(
                "dbo.Nomenclatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(nullable: false),
                        NormRef = c.String(nullable: false),
                        Condition = c.String(nullable: false),
                        ColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NColors", t => t.ColorId, cascadeDelete: true)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.NColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NomenclatureSequances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomenclatureID = c.Int(nullable: false),
                        SequenceId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                        Mass = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Sequences", t => t.SequenceId, cascadeDelete: true)
                .ForeignKey("dbo.Nomenclatures", t => t.NomenclatureID, cascadeDelete: true)
                .Index(t => t.NomenclatureID)
                .Index(t => t.SequenceId)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RawMaterials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComposantID = c.Int(nullable: false),
                        Matricule = c.String(nullable: false),
                        Mass = c.Single(nullable: false),
                        Lot = c.String(nullable: false),
                        ImpDate = c.DateTime(nullable: false),
                        UpDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Components", t => t.ComposantID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ComposantID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ImportingInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuplierId = c.Int(nullable: false),
                        RawMaterialId = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        PaymentStatus = c.Byte(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UsedRawMaterial_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RawMaterials", t => t.RawMaterialId)
                .ForeignKey("dbo.Supliers", t => t.SuplierId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UsedRawMaterials", t => t.UsedRawMaterial_Id)
                .Index(t => t.SuplierId)
                .Index(t => t.RawMaterialId)
                .Index(t => t.UserId)
                .Index(t => t.UsedRawMaterial_Id);
            
            CreateTable(
                "dbo.Supliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 30, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 15, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Phone = c.Int(nullable: false),
                        Adress = c.String(nullable: false, maxLength: 120, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileImage = c.Binary(),
                        UserName = c.String(nullable: false, maxLength: 4000),
                        FullName = c.String(nullable: false, maxLength: 4000),
                        Adress = c.String(nullable: false, maxLength: 4000),
                        ZipCode = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 4000),
                        Phone = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 4000),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Expences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Payment = c.Single(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        ExpenceCatId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenceCats", t => t.ExpenceCatId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ExpenceCatId);
            
            CreateTable(
                "dbo.ExpenceCats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20, unicode: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MessageId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 200, unicode: false),
                        Deadline = c.DateTime(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsedRawMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FabOrdID = c.Int(nullable: false),
                        RawMaterialID = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FabricationOrders", t => t.FabOrdID, cascadeDelete: true)
                .ForeignKey("dbo.RawMaterials", t => t.RawMaterialID, cascadeDelete: true)
                .Index(t => t.FabOrdID)
                .Index(t => t.RawMaterialID);
            
            CreateTable(
                "dbo.Sequences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProgressionChecks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OFID = c.Int(nullable: false),
                        SeqID = c.Int(nullable: false),
                        Progress = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FabricationOrders", t => t.OFID, cascadeDelete: true)
                .ForeignKey("dbo.Sequences", t => t.SeqID, cascadeDelete: true)
                .Index(t => t.OFID)
                .Index(t => t.SeqID);
            
            CreateTable(
                "dbo.GroupMessages",
                c => new
                    {
                        MassegeId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MassegeId, t.GroupId })
                .ForeignKey("dbo.Messages", t => t.MassegeId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.MassegeId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.GroupTasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TaskId, t.GroupId })
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellingInvoices", "UserId", "dbo.Users");
            DropForeignKey("dbo.SellingInvoices", "FabOrdId", "dbo.FabricationOrders");
            DropForeignKey("dbo.FabricationOrders", "NomenclatureId", "dbo.Nomenclatures");
            DropForeignKey("dbo.NomenclatureSequances", "NomenclatureID", "dbo.Nomenclatures");
            DropForeignKey("dbo.NomenclatureSequances", "SequenceId", "dbo.Sequences");
            DropForeignKey("dbo.ProgressionChecks", "SeqID", "dbo.Sequences");
            DropForeignKey("dbo.ProgressionChecks", "OFID", "dbo.FabricationOrders");
            DropForeignKey("dbo.NomenclatureSequances", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.RawMaterials", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsedRawMaterials", "RawMaterialID", "dbo.RawMaterials");
            DropForeignKey("dbo.ImportingInvoices", "UsedRawMaterial_Id", "dbo.UsedRawMaterials");
            DropForeignKey("dbo.UsedRawMaterials", "FabOrdID", "dbo.FabricationOrders");
            DropForeignKey("dbo.ImportingInvoices", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupTasks", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupTasks", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.UserMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserMessages", "MessageId", "dbo.Messages");
            DropForeignKey("dbo.GroupMessages", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupMessages", "MassegeId", "dbo.Messages");
            DropForeignKey("dbo.GroupPermissions", "PermissionId", "dbo.Permissions");
            DropForeignKey("dbo.GroupPermissions", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Expences", "UserId", "dbo.Users");
            DropForeignKey("dbo.Expences", "ExpenceCatId", "dbo.ExpenceCats");
            DropForeignKey("dbo.ImportingInvoices", "SuplierId", "dbo.Supliers");
            DropForeignKey("dbo.ImportingInvoices", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.RawMaterials", "ComposantID", "dbo.Components");
            DropForeignKey("dbo.Nomenclatures", "ColorId", "dbo.NColors");
            DropForeignKey("dbo.SellingInvoices", "ClientId", "dbo.Clients");
            DropIndex("dbo.GroupTasks", new[] { "GroupId" });
            DropIndex("dbo.GroupTasks", new[] { "TaskId" });
            DropIndex("dbo.GroupMessages", new[] { "GroupId" });
            DropIndex("dbo.GroupMessages", new[] { "MassegeId" });
            DropIndex("dbo.ProgressionChecks", new[] { "SeqID" });
            DropIndex("dbo.ProgressionChecks", new[] { "OFID" });
            DropIndex("dbo.UsedRawMaterials", new[] { "RawMaterialID" });
            DropIndex("dbo.UsedRawMaterials", new[] { "FabOrdID" });
            DropIndex("dbo.UserMessages", new[] { "MessageId" });
            DropIndex("dbo.UserMessages", new[] { "UserId" });
            DropIndex("dbo.GroupPermissions", new[] { "PermissionId" });
            DropIndex("dbo.GroupPermissions", new[] { "GroupId" });
            DropIndex("dbo.Expences", new[] { "ExpenceCatId" });
            DropIndex("dbo.Expences", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "GroupId" });
            DropIndex("dbo.ImportingInvoices", new[] { "UsedRawMaterial_Id" });
            DropIndex("dbo.ImportingInvoices", new[] { "UserId" });
            DropIndex("dbo.ImportingInvoices", new[] { "RawMaterialId" });
            DropIndex("dbo.ImportingInvoices", new[] { "SuplierId" });
            DropIndex("dbo.RawMaterials", new[] { "UserId" });
            DropIndex("dbo.RawMaterials", new[] { "ComposantID" });
            DropIndex("dbo.NomenclatureSequances", new[] { "ComponentId" });
            DropIndex("dbo.NomenclatureSequances", new[] { "SequenceId" });
            DropIndex("dbo.NomenclatureSequances", new[] { "NomenclatureID" });
            DropIndex("dbo.Nomenclatures", new[] { "ColorId" });
            DropIndex("dbo.FabricationOrders", new[] { "NomenclatureId" });
            DropIndex("dbo.SellingInvoices", new[] { "UserId" });
            DropIndex("dbo.SellingInvoices", new[] { "ClientId" });
            DropIndex("dbo.SellingInvoices", new[] { "FabOrdId" });
            DropTable("dbo.GroupTasks");
            DropTable("dbo.GroupMessages");
            DropTable("dbo.ProgressionChecks");
            DropTable("dbo.Sequences");
            DropTable("dbo.UsedRawMaterials");
            DropTable("dbo.Tasks");
            DropTable("dbo.UserMessages");
            DropTable("dbo.Messages");
            DropTable("dbo.Permissions");
            DropTable("dbo.GroupPermissions");
            DropTable("dbo.Groups");
            DropTable("dbo.ExpenceCats");
            DropTable("dbo.Expences");
            DropTable("dbo.Users");
            DropTable("dbo.Supliers");
            DropTable("dbo.ImportingInvoices");
            DropTable("dbo.RawMaterials");
            DropTable("dbo.Components");
            DropTable("dbo.NomenclatureSequances");
            DropTable("dbo.NColors");
            DropTable("dbo.Nomenclatures");
            DropTable("dbo.FabricationOrders");
            DropTable("dbo.SellingInvoices");
            DropTable("dbo.Clients");
        }
    }
}
