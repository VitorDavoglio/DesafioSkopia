
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskManager.DI;
using TaskManager.Filter;
using TaskManager.Infra.Data.Context;

namespace TaskManager
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .Build();


            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter>();
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAllOrigins",
                                      policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            Bootstrapper.InjectDependencies(builder.Services, builder.Configuration);

            var app = builder.Build();
            var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<TaskManagerDbContext>();
                dbContext.Database.EnsureCreated();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.Run();
        }
    }
}
