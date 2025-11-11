using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Infra.Data.Mappings;
using TaskManager.Infra.Data.ValueGenerators;

namespace TaskManager.Infra.Data.Configs
{
    public class TaskCommentConfig : IEntityTypeConfiguration<TaskCommentMapping>
    {
        public void Configure(EntityTypeBuilder<TaskCommentMapping> comment)
        {
            comment.HasKey(x => x.Id);
            comment.Property(x => x.Id).ValueGeneratedOnAdd();
            comment.Property(x => x.Created).HasValueGenerator<NowValueGenerator>();
        }
    }
}
