using System.Linq;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IQueryRepository<TEntity> where TEntity : class
    {
        TEntity Find(TEntity filter);
        IQueryable<TEntity> Where(TEntity filter);
        IQueryable<TEntity> GetAll();
        bool Any(TEntity filter);
        int Count(TEntity filter);
    }
}
