using Microsoft.AspNetCore.Mvc.Filters;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Interfaces.Repositories;

namespace TaskManager.Filter
{
    public class RoleFilterAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => false;
        public UserRole[] AllowedRoles { get; set; }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new RoleFilter(AllowedRoles, serviceProvider.GetRequiredService<IQueryRepository<User>>());
        }
    }
}
