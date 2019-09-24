using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class UsedRawMaterialConfiguration : EntityTypeConfiguration<UsedRawMaterial>
    {
        public UsedRawMaterialConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Weight)
                .IsRequired();

            HasRequired(c => c.FabricationOrder)
                .WithMany(c => c.UsedRawMaterials)
                .HasForeignKey(c => c.FabOrdID);

            HasRequired(c => c.RawMaterial)
                .WithMany(c => c.UsedRawMaterials)
                .HasForeignKey(c => c.RawMaterialID);
        }
    }
}
