using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Mappings;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.Infra.Data.Repository
{
    public class ProjectRepository : BaseRepository<ProjectMapping>, ICommandRepository<Project>, IQueryRepository<Project>
    {
        public ProjectRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAsync(Project entity)
        {
            await base.AddAsync((ProjectMapping)entity);
        }
        public async Task DeleteAsync(Project entity)
        {
            await base.DeleteAsync((ProjectMapping)entity);
        }
        public Project Find(Project filter)
        {
            var mapping = _dbContext.Set<ProjectMapping>()
                                     .FirstOrDefault(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                      (filter.Owner == null || filter.Owner.Id == null || filter.Owner.Id == entity.Owner.Id) &&
                                                      (filter.Owner == null || string.IsNullOrWhiteSpace(filter.Owner.Name) || filter.Owner.Name == entity.Owner.Name) &&
                                                      (filter.Owner == null || string.IsNullOrWhiteSpace(filter.Owner.Account) || filter.Owner.Account == entity.Owner.Account));
            return (Project)mapping;
        }
        public async Task UpdateAsync(Project entity)
        {
            await base.UpdateAsync((ProjectMapping)entity);
        }
        public IQueryable<Project> Where(Project filter)
        {
            var mapping = _dbContext.Set<ProjectMapping>().AsNoTracking()
                                    .Where(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                     (filter.OwnerId == null || filter.OwnerId == default || filter.OwnerId == entity.OwnerId) &&
                                                     (filter.Owner == null || string.IsNullOrWhiteSpace(filter.Owner.Name) || filter.Owner.Name == entity.Owner.Name) &&
                                                     (filter.Owner == null || string.IsNullOrWhiteSpace(filter.Owner.Account) || filter.Owner.Account == entity.Owner.Account));
            return mapping.Select(x => (Project)x);
        }
        public IQueryable<Project> GetAll()
        {
            return _dbContext.Set<ProjectMapping>().AsNoTracking().Select(x => (Project)x);
        }
        public bool Any(Project filter)
        {
            return _dbContext.Set<ProjectMapping>().AsNoTracking()
                                    .Any(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                     (filter.Owner == null || filter.Owner.Id == null || filter.Owner.Id == entity.Owner.Id) &&
                                                     (filter.Owner == null || string.IsNullOrWhiteSpace(filter.Owner.Name) || filter.Owner.Name == entity.Owner.Name) &&
                                                     (filter.Owner == null || string.IsNullOrWhiteSpace(filter.Owner.Account) || filter.Owner.Account == entity.Owner.Account));
        }
        public int Count(Project filter)
        {
            return _dbContext.Set<ProjectMapping>().AsNoTracking()
                                    .Count(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                     (filter.Owner == null || filter.Owner.Id == null || filter.Owner.Id == entity.Owner.Id) &&
                                                     (filter.Owner == null || string.IsNullOrWhiteSpace(filter.Owner.Name) || filter.Owner.Name == entity.Owner.Name) &&
                                                     (filter.Owner == null || string.IsNullOrWhiteSpace(filter.Owner.Account) || filter.Owner.Account == entity.Owner.Account));
        }
    }
}
