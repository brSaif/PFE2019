using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Task = VEGAACABLE.BL.Domain.Task;

namespace VEGAACABLE.DAL.EntityConfigurations
{
    public class TaskConfiguration :EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar");
        }
    }
}
