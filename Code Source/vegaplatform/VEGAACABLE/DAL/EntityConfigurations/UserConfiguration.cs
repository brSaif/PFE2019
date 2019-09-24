using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(u =>  u.Id);

            Property(u => u.Adress)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(u => u.Email)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(u => u.FullName)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(u => u.ProfileImage)
                .IsOptional();

            Property(u => u.Password)
                .IsRequired()
                .HasColumnType("nvarchar");

            Property(u => u.UserName)
                .IsRequired()
                .HasColumnType("nvarchar");

            HasRequired(u => u.Group)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.GroupId);

        }
    }
}
