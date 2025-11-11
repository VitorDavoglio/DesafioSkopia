using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Interfaces.Services;
using TaskManager.Domain.Services;

namespace TaskManager.Domain.DI
{
    public static class Resolver
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITaskService,TaskService>();
            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}
