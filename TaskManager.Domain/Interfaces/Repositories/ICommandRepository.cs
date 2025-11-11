using System.Threading.Tasks;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface ICommandRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
