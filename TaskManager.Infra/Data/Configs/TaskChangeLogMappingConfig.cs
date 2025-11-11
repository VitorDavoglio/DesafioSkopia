using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Data.Mappings;

namespace TaskManager.Infra.Data.Configs
{
    public class TaskChangeLogMappingConfig : IEntityTypeConfiguration<TaskChangeLogMapping>
    {
        public void Configure(EntityTypeBuilder<TaskChangeLogMapping> changeLog)
        {
            changeLog.HasKey(x => x.Id);
            changeLog.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
