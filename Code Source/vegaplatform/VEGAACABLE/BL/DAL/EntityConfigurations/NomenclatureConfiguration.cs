using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class NomenclatureConfiguration : EntityTypeConfiguration<Nomenclature>
    {
        public NomenclatureConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Condition)
                .IsRequired();

            Property(c => c.Designation)
                .IsRequired();

            Property(c => c.NormRef)
                .IsRequired();

            HasRequired(c => c.Color)
                .WithMany(c => c.Nomenclatures)
                .HasForeignKey(c => c.ColorId);

            HasMany(c => c.NomenclatureSequances)
                .WithRequired(c => c.Nomenclature)
                .HasForeignKey(c => c.NomenclatureID);

        }
    }

}
