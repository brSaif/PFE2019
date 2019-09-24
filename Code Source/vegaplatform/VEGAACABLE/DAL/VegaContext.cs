using System.Configuration;
using System.Data.Entity;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.DAL.EntityConfigurations;

namespace VEGAACABLE.DAL
{
    public class VegaContext : DbContext
    {
        public static string stri = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //public static string con = @"Data Source = .; Initial Catalog=VegaCable; Integrated Security=True"; User Id = sa; Password = M@ut%^k/12#3456;
        public static string con = $@"{stri}; Initial Catalog=VegaPlatform";

        public VegaContext()
                      :base(con)
        {
            //this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Client> clients { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Expence> Expences { get; set; }
        public virtual DbSet<ExpenceCat> ExpenceCats { get; set; }
        public virtual DbSet<FabricationOrder> FabricationOrders { get; set; }
        public virtual DbSet<ImportingInvoice> ImportingInvoices { get; set; }
        public virtual DbSet<NColor> NColors { get; set; }
        public virtual DbSet<Nomenclature> Nomenclatures { get; set; }
        public virtual DbSet<NomenclatureSequance> NomenclatureSequances { get; set; }
        public virtual DbSet<ProgressionCheck> ProgressionChecks { get; set; }
        public virtual DbSet<RawMaterial> RawMaterials { get; set; }
        public virtual DbSet<SellingInvoice> SellingInvoices { get; set; }
        public virtual DbSet<Sequence> Sequences { get; set; }
        public virtual DbSet<Suplier> Supliers { get; set; }
        public virtual DbSet<UGroup> UGroups { get; set; }
        public virtual DbSet<UGroupPermission> UGroupPermissions { get; set; }
        public virtual DbSet<UPermission> UPermissions { get; set; }
        public virtual DbSet<UsedRawMaterial> UsedRawMaterials { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new ExpenceConfiguration());
            modelBuilder.Configurations.Add(new FabricationOrderConfiguration());
            modelBuilder.Configurations.Add(new ImportingInvoiceConfiguration());
            modelBuilder.Configurations.Add(new NomenclatureConfiguration());
            modelBuilder.Configurations.Add(new NomenclatureSequenceConfiguration());
            modelBuilder.Configurations.Add(new ProgressionCheckConfiguration());
            modelBuilder.Configurations.Add(new RawMaterialConfiguration());
            modelBuilder.Configurations.Add(new SellingInvoiceConfiguration());
            modelBuilder.Configurations.Add(new SuplierConfiguration());
            modelBuilder.Configurations.Add(new UGroupConfiguration());
            modelBuilder.Configurations.Add(new UGroupPermissionConfiguration());
            modelBuilder.Configurations.Add(new UPermissionConfiguration());
            modelBuilder.Configurations.Add(new UsedRawMaterialConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
