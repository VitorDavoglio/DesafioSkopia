using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain.Aggregate;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Mappings;

namespace TaskManager.Infra.Data.Repository
{
    public class TaskChangeLogRepository : BaseRepository<TaskChangeLogMapping>, ICommandRepository<TaskChangeLog>, IQueryRepository<TaskChangeLog>
    {
        public TaskChangeLogRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {

        }

        public async Task AddAsync(TaskChangeLog entity)
        {
            foreach (var change in entity.Changes)
            {
                var newEntity = new TaskChangeLogMapping()
                {
                    Field = change.Field,
                    PreviousValue = change.PreviousValue,
                    TaskId = entity.TaskId,
                    UpdateDate = change.UpdateDate,
                    UpdatedValue = change.UpdatedValue,
                    UpdaterId = change.UpdaterId,
                };
                await base.AddAsync(newEntity);
            }
        }
        public async Task DeleteAsync(TaskChangeLog entity)
        {
            throw new NotImplementedException();
        }
        public TaskChangeLog Find(TaskChangeLog filter)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateAsync(TaskChangeLog entity)
        {
            throw new NotImplementedException();
        }
        public IQueryable<TaskChangeLog> Where(TaskChangeLog filter)
        {
            var mapping = _dbContext.Set<TaskChangeLogMapping>().AsNoTracking()
                                    .Where(entity => (filter.TaskId == null || filter.TaskId == default || filter.TaskId == entity.TaskId)).GroupBy(x => x.TaskId);

            var results = mapping.Select(group => new TaskChangeLog()
            {
                TaskId = group.Key,
                Changes = group.Select(mapping =>
                     new Domain.ValueObjects.TaskChange()
                     {
                         Field = mapping.Field,
                         PreviousValue = mapping.PreviousValue,
                         UpdateDate = mapping.UpdateDate,
                         UpdatedValue = mapping.UpdatedValue,
                         UpdaterId = mapping.UpdaterId,
                     }
                )
            });

            return results;

        }
        public IQueryable<TaskChangeLog> GetAll()
        {
            throw new NotImplementedException();
        }
        public bool Any(TaskChangeLog filter)
        {
            throw new NotImplementedException();
        }
        public int Count(TaskChangeLog filter)
        {
            throw new NotImplementedException();
        }

    }
}
