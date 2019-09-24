using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Adress)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar");

            Property(c => c.Company)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnType("varchar");

            Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnType("varchar");

            Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnType("varchar");

            Property(c => c.Phone)
                .HasColumnType("int")
                .IsRequired();

        }
    }
}
