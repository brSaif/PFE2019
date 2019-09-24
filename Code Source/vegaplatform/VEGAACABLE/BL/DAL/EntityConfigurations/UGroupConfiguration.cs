using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class UGroupConfiguration : EntityTypeConfiguration<UGroup>
    {
        public UGroupConfiguration()
        {

            ToTable("Groups");

            HasKey(g => g.Id);

            Property(g => g.Name)
                .IsRequired()
                .HasColumnType("Varchar")
                .HasMaxLength(15);

        }
    }
}
