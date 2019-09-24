using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class SellingInvoiceConfiguration : EntityTypeConfiguration<SellingInvoice>
    {
        public SellingInvoiceConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Price)
                .IsRequired();

            Property(c => c.Discount)
                .IsRequired();

            HasRequired(c => c.Client)
                .WithMany(c => c.SellingInvoices)
                .HasForeignKey(c => c.ClientId);

            HasRequired(c => c.FabricationOrder)
                .WithMany(c => c.SellingInvoices)
                .HasForeignKey(c => c.FabOrdId);

            HasRequired(c => c.User)
                .WithMany(c => c.SellingInvoices)
                .HasForeignKey(c => c.UserId);
        }
    }
}
