using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class MessageConfiguration:EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(60);

            Property(c => c.Content)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(250);

            HasMany(c => c.UGroups)
                .WithMany(c => c.Messages)
                .Map(c =>
                {
                    c.ToTable("GroupMessages");
                    c.MapLeftKey("MassegeId");
                    c.MapRightKey("GroupId");
                });

        }
    }
}
