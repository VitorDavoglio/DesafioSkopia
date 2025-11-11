using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;
using TaskManager.Infra.Data.Mappings;

namespace TaskManager.Infra.Data.Configs
{
    public class ProjectMappingConfig : IEntityTypeConfiguration<ProjectMapping>
    {
        public void Configure(EntityTypeBuilder<ProjectMapping> project)
        {
            project.HasKey(x => x.Id);
            project.Property(x => x.Id).ValueGeneratedOnAdd();
            project.HasOne(x => x.Owner).WithMany(x => x.Projects).HasForeignKey(x => x.OwnerId);
            project.HasMany(x => x.Tasks).WithOne(x => x.Project);
        }
    }
}
