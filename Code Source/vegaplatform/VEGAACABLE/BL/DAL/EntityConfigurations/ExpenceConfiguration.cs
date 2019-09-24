
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class ExpenceConfiguration : EntityTypeConfiguration<Expence>
    {
        public ExpenceConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Payment)
                .IsRequired();

            HasRequired(e => e.ExpenceCat)
                .WithMany(e => e.Expences)
                .HasForeignKey(e => e.ExpenceCatId);

            HasRequired(e => e.User)
                .WithMany(e => e.Expences)
                .HasForeignKey(e => e.UserId);

        }
    }
}
