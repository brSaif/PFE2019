using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class NomenclatureSequenceConfiguration : EntityTypeConfiguration<NomenclatureSequance>
    {
        public NomenclatureSequenceConfiguration()
        {
            HasKey(c => c.ID);

            Property(c => c.Mass)
                .IsRequired();

            HasRequired(c => c.Sequence)
                .WithMany(c => c.NomenclatureSequances)
                .HasForeignKey(c => c.SequenceId);

            HasRequired(c => c.Component)
                .WithMany(c => c.NomenclatureSequances)
                .HasForeignKey(c => c.ComponentId);
        }
    }
}
