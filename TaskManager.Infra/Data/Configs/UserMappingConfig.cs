using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TaskManager.Infra.Data.Mappings;

namespace TaskManager.Infra.Data.Configs
{
    public class UserMappingConfig : IEntityTypeConfiguration<UserMapping>
    {
        public void Configure(EntityTypeBuilder<UserMapping> user)
        {
            user.HasKey(x => x.Id);
            user.Property(x => x.Id).ValueGeneratedOnAdd();
            user.HasMany(x => x.Projects).WithOne(x=>x.Owner);
        }
    }
}
