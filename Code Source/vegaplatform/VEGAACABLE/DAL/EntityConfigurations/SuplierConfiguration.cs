using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class SuplierConfiguration : EntityTypeConfiguration<Suplier>
    {
        public SuplierConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Adress)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(120);

            Property(c => c.Company)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(30);

            Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(c => c.FirstName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(15);

            Property(c => c.LastName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(15);

        }
    }
}
