using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class ImportingInvoiceConfiguration : EntityTypeConfiguration<ImportingInvoice>
    {
        public ImportingInvoiceConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Price)
                .IsRequired();

            Property(c => c.Discount)
                .IsRequired();

            HasRequired(c => c.RawMaterial)
                .WithMany(c => c.ImportingInvoices)
                .HasForeignKey(c => c.RawMaterialId)
                .WillCascadeOnDelete(false); 

            HasRequired(c => c.Suplier)
                .WithMany(c => c.ImportingInvoices)
                .HasForeignKey(c => c.SuplierId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.User)
                .WithMany(c => c.ImportingInvoices)
                .HasForeignKey(c => c.UserId);
        }
    }
}
