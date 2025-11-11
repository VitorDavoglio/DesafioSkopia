using System.Threading.Tasks;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Context;

namespace TaskManager.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class
    {
        protected readonly TaskManagerDbContext _dbContext;
        public BaseRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }
        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

    }
}
