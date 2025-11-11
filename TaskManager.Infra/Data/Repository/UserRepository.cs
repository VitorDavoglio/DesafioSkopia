using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Mappings;

namespace TaskManager.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<UserMapping>, IQueryRepository<User>
    {
        public UserRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {
        }

        public bool Any(User filter)
        {
            var mapping = _dbContext.Set<UserMapping>()
                               .Any(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                (filter.Account == null || string.IsNullOrWhiteSpace(filter.Account) || filter.Account == entity.Account) &&
                                                (filter.Name == null || string.IsNullOrWhiteSpace(filter.Name) || filter.Name == entity.Name));

            return mapping;
        }

        public int Count(User filter)
        {
            var mapping = _dbContext.Set<UserMapping>()
                               .Count(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                (filter.Account == null || string.IsNullOrWhiteSpace(filter.Account) || filter.Account == entity.Account) &&
                                                (filter.Name == null || string.IsNullOrWhiteSpace(filter.Name) || filter.Name == entity.Name));
            return mapping;
        }

        public User Find(User filter)
        {
            var mapping = _dbContext.Set<UserMapping>().AsNoTracking()
                                 .FirstOrDefault(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                  (filter.Account == null || string.IsNullOrWhiteSpace(filter.Account) || filter.Account == entity.Account) &&
                                                  (filter.Name == null || string.IsNullOrWhiteSpace(filter.Name) || filter.Name == entity.Name));
            return  (User)mapping;
        }

        public IQueryable<User> GetAll()
        {
            var mapping = _dbContext.Set<UserMapping>().AsNoTracking();
            return mapping.Select(x => (User)x);
        }

        public IQueryable<User> Where(User filter)
        {
            var mapping = _dbContext.Set<UserMapping>().AsNoTracking()
                                .Where(entity => (filter.Id == null || filter.Id == entity.Id) &&
                                                 (filter.Account == null || string.IsNullOrWhiteSpace(filter.Account) || filter.Account == entity.Account) &&
                                                 (filter.Name == null || string.IsNullOrWhiteSpace(filter.Name) || filter.Name == entity.Name));
            return mapping.Select(x => (User)x);
        }
    }
}
