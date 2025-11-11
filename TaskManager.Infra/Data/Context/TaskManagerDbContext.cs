using Microsoft.EntityFrameworkCore;
using TaskManager.Infra.Data.Mappings;

namespace TaskManager.Infra.Data.Context
{
    public class TaskManagerDbContext(DbContextOptions opt) : DbContext(opt)
    {
        public DbSet<TaskMapping> Tasks { get; set; }
        public DbSet<ProjectMapping> Projects { get; set; }
        public DbSet<UserMapping> Users { get; set; }
        public DbSet<TaskChangeLogMapping> TaskChangeLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskMapping).Assembly);
        }
    }
}
