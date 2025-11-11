using System;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.ValueObjects;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Mappings;

namespace TaskManager.Infra.Data.Repository
{
    public class TaskCommentRepository : BaseRepository<TaskCommentMapping>, ICommandRepository<TaskComment>
    {
        public TaskCommentRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAsync(TaskComment entity)
        {
            await base.AddAsync((TaskCommentMapping)entity);
        }

        public async Task DeleteAsync(TaskComment entity)
        {
            await base.DeleteAsync((TaskCommentMapping)entity);
        }

        public async Task UpdateAsync(TaskComment entity)
        {
            await base.UpdateAsync((TaskCommentMapping)entity);
        }
    }
}
