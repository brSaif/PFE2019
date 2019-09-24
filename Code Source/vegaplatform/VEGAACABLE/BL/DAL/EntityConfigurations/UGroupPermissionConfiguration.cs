using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class UGroupPermissionConfiguration : EntityTypeConfiguration<UGroupPermission>
    {
        public UGroupPermissionConfiguration()
        {
            ToTable("GroupPermissions");

            HasKey(g => g.Id);

            HasRequired(c => c.Group)
                .WithMany(c => c.GroupPermissions)
                .HasForeignKey(c => c.GroupId);

            HasRequired(c => c.Permission)
                .WithMany(c => c.GroupPermissions)
                .HasForeignKey(c => c.PermissionId);
        }
    }
}
