using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TaskManager.Domain.Aggregate;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.ValueObjects;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Mappings;
using TaskManager.Infra.Data.Repository;

namespace TaskManager.Infra.Data.DI
{
    public static class Resolver
    {

        public static void AddInMemoryDb(this IServiceCollection services, string connString)
        {
            services.AddDbContext<TaskManagerDbContext>(opt =>
            {
                opt.UseInMemoryDatabase(connString);
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSeeding((ctx,_) =>
                {
                    ctx.Set<UserMapping>().AddRange(new List<UserMapping>() {
                        new UserMapping { Id = Guid.Parse("2712be0f-6146-4f74-b66e-dec1bb84fa8c"), Name = "Dev", Account = "dev@taskmanagerapp.com", Role = Domain.Enums.UserRole.Developer },
                        new UserMapping { Id = Guid.Parse("df737e18-1699-4626-a8fd-54b450fe69d8"), Name = "Manager", Account = "manager@taskmanagerapp.com", Role = Domain.Enums.UserRole.Manager } }
                    );
                    ctx.SaveChanges();
                });
            }, ServiceLifetime.Singleton);

        }
        public static void InjectCommandRepos(this IServiceCollection services)
        {
            services.AddScoped<ICommandRepository<Project>, ProjectRepository>();
            services.AddScoped<ICommandRepository<Task>, TaskRepository>();
            services.AddScoped<ICommandRepository<TaskChangeLog>, TaskChangeLogRepository>();
            services.AddScoped<ICommandRepository<TaskComment>, TaskCommentRepository>();

        }
        public static void InjectQueryRepos(this IServiceCollection services)
        {
            services.AddScoped<IQueryRepository<Project>, ProjectRepository>();
            services.AddScoped<IQueryRepository<Task>, TaskRepository>();
            services.AddScoped<IQueryRepository<User>, UserRepository>();
            services.AddScoped<IQueryRepository<TaskChangeLog>, TaskChangeLogRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
        }
    }
}
