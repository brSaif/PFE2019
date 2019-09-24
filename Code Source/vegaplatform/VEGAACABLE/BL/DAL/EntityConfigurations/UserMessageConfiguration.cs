using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class UserMessageConfiguration : EntityTypeConfiguration<UserMessage>
    {
        public UserMessageConfiguration()
        {
            ToTable("UserMessages");

            HasKey(c => c.Id);

            HasRequired(c => c.Message)
                .WithMany(c => c.UserMessages)
                .HasForeignKey(c => c.MessageId);

            HasRequired(c => c.User)
                .WithMany(c => c.UserMessages)
                .HasForeignKey(c => c.UserId);

        }
    }
}
