using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class FabricationOrderConfiguration : EntityTypeConfiguration<FabricationOrder>
    {
        public FabricationOrderConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Length)
                .IsRequired();

            HasRequired(c => c.Nomenclature)
                .WithMany(c => c.FabricationOrders)
                .HasForeignKey(c => c.NomenclatureId);
        }
    }
}
