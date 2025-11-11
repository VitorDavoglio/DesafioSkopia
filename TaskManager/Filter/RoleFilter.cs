using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Interfaces.Repositories;

namespace TaskManager.Filter
{
    public class RoleFilter : ActionFilterAttribute
    {
        public bool IsReusable => true;
        public UserRole[] AllowedRoles { get; set; }
        private readonly IQueryRepository<User> UserQueryRepo;

        public RoleFilter(UserRole[] allowedRoles, IQueryRepository<User> userQueryRepo)
        {
            AllowedRoles = allowedRoles;
            UserQueryRepo = userQueryRepo;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authUser = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "logged-user-id").Value.ToString();
            if (authUser == null) {
                throw new UnauthorizedAccessException("ÍD de usuário não informado no header da requisição");
            } else {
                var authUserInfo = UserQueryRepo.Find(new User() { Id = Guid.Parse(authUser) });
                if (!AllowedRoles.Contains(authUserInfo.Role))
                {
                    throw new UnauthorizedAccessException("Usuário sem acesso aos relatórios.");
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
