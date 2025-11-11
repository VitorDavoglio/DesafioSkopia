using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Mappings;
using Threading = System.Threading.Tasks;

namespace TaskManager.Infra.Data.Repository
{
    public class TaskRepository : BaseRepository<TaskMapping>, ICommandRepository<Task>, IQueryRepository<Task>
    {
        public TaskRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Threading.Task AddAsync(Task entity)
        {
            await base.AddAsync((TaskMapping)entity);

        }
        public async Threading.Task DeleteAsync(Task entity)
        {
            await base.DeleteAsync((TaskMapping)entity);
        }
        public Task Find(Task filter)
        {
            var mapping = _dbContext.Set<TaskMapping>().AsNoTracking()
                                      .FirstOrDefault(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                                (filter.Project == null || filter.Project.Id == null || filter.Project.Id == entity.ProjectId) &&
                                                                (filter.CurrentStatus == null || filter.CurrentStatus == entity.CurrentStatus) &&
                                                                (filter.DueDate == null || filter.DueDate == entity.DueDate) &&
                                                                (filter.Description == null || string.IsNullOrWhiteSpace(filter.Description) || filter.Description == entity.Description));
            return (Task)mapping;
        }
        public async Threading.Task UpdateAsync(Task entity)
        {
            await base.UpdateAsync((TaskMapping)entity);
        }
        public IQueryable<Task> Where(Task filter)
        {
            var mapping = _dbContext.Set<TaskMapping>().AsNoTracking()
                                    .Include(x => x.ChangeHistory)
                                    .Include(x => x.Comments)
                                    .Where(entity => (filter.Id == null || filter.Id == default || filter.Id == entity.Id) &&
                                                              (filter.ProjectId == null || filter.ProjectId == default || filter.ProjectId == entity.ProjectId) &&
                                                              (filter.CurrentStatus == null || filter.CurrentStatus == entity.CurrentStatus) &&
                                                              (filter.DueDate == null || filter.DueDate == entity.DueDate) &&
                                                              (filter.Description == null || string.IsNullOrWhiteSpace(filter.Description) || filter.Description == entity.Description));
            return mapping.Select(x => (Task)x);
        }
        public IQueryable<Task> GetAll()
        {
            return _dbContext.Set<TaskMapping>().AsNoTracking().Select(x => (Task)x);
        }
        public bool Any(Task filter)
        {
            var mapping = _dbContext.Set<TaskMapping>().AsNoTracking()
                          .Any(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                    (filter.ProjectId == null || filter.ProjectId == default || filter.ProjectId == entity.ProjectId) &&
                                                    (filter.CurrentStatus == null || filter.CurrentStatus == entity.CurrentStatus) &&
                                                    (filter.DueDate == null || filter.DueDate == entity.DueDate) &&
                                                    (filter.Description == null || string.IsNullOrWhiteSpace(filter.Description) || filter.Description == entity.Description));
            return mapping;
        }
        public int Count(Task filter)
        {
            var mapping = _dbContext.Set<TaskMapping>().AsNoTracking()
                                   .Count(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                             (filter.ProjectId == null || filter.ProjectId == default || filter.ProjectId == entity.ProjectId) &&
                                                             (filter.CurrentStatus == null || filter.CurrentStatus == entity.CurrentStatus) &&
                                                             (filter.DueDate == null || filter.DueDate == entity.DueDate) &&
                                                             (filter.Description == null || string.IsNullOrWhiteSpace(filter.Description) || filter.Description == entity.Description));
            return mapping;
        }

    }
}
