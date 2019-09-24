using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class ProgressionCheckConfiguration : EntityTypeConfiguration<ProgressionCheck>
    {
        public ProgressionCheckConfiguration()
        {
            HasKey(c => c.ID);

            HasRequired(c => c.FabricationOrder)
                .WithMany(c => c.ProgressionChecks)
                .HasForeignKey(c => c.OFID);

            HasRequired(c => c.Sequence)
                .WithMany(c => c.ProgressionChecks)
                .HasForeignKey(c => c.SeqID);
        }
    }
}
