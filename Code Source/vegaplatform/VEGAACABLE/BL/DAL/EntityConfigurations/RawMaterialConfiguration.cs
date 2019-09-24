using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class RawMaterialConfiguration : EntityTypeConfiguration<RawMaterial>
    {
        public RawMaterialConfiguration()
        {
            HasKey(c => c.ID);

            Property(c => c.Lot)
                .IsRequired();

            Property(c => c.RefNbr)
                .IsRequired();

            Property(c => c.Mass)
                .IsRequired();

            HasRequired(c => c.Composant)
                .WithMany(c => c.RawMaterials)
                .HasForeignKey(c => c.ComposantID);

            HasRequired(c => c.User)
                .WithMany(c => c.RawMaterials)
                .HasForeignKey(c => c.UserId);
        }
    }
}
