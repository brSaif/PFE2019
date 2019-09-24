using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class UPermissionConfiguration :  EntityTypeConfiguration<UPermission>
    {
        public UPermissionConfiguration()
        {
            ToTable("Permissions");

            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

            
        }
    }
}
