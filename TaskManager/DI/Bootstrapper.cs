
using TaskManager.Filter;

namespace TaskManager.DI
{
    public static class Bootstrapper
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            Infra.Data.DI.Resolver.AddInMemoryDb(services, configuration.GetConnectionString("TaskManagerDb"));
            Application.DI.Resolver.InjectDependencies(services);
            Domain.DI.Resolver.InjectDependencies(services);
            Infra.Data.DI.Resolver.InjectCommandRepos(services);
            Infra.Data.DI.Resolver.InjectQueryRepos(services);
        }
    }
}
