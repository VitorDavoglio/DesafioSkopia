using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TaskManager.Domain.Enums;
using TaskManager.Infra.Data.Mappings;

namespace TaskManager.Infra.Data.Configs
{
    public class TaskMappingConfig : IEntityTypeConfiguration<TaskMapping>
    {
        public void Configure(EntityTypeBuilder<TaskMapping> task)
        {
            task.HasKey(x => x.Id);
            task.Property(x => x.Id).ValueGeneratedOnAdd();
            task.HasOne(x => x.Project).WithMany(x => x.Tasks).HasForeignKey(x=>x.ProjectId);
            task.HasMany(x => x.ChangeHistory).WithOne().HasForeignKey(x=>x.TaskId);
            task.HasMany(x => x.Comments).WithOne().HasForeignKey(x => x.TaskId);

            task.Property(x => x.CurrentStatus).HasConversion(
                writeValue => writeValue.ToString(),
                readValue => Enum.Parse<TaskStatus>(readValue));
            
            task.Property(x => x.Priority).HasConversion(
                writeValue => writeValue.ToString(),
                readValue => Enum.Parse<TaskPriority>(readValue));
        }
    }
}
