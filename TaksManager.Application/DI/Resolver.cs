using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManager.Application.Handlers;

namespace TaskManager.Application.DI
{
    public static class Resolver
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(ProjectCommandsHandler))));
        }
    }
}
