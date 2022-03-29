using CodeFirst.Core.Interfaces.Repositories;
using CodeFirst.Infrastructure.Repositories;
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeFirst.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CodeFirstContext>(options =>
            options.UseSqlServer(connectionString: configuration.GetConnectionString("CodeFirst")));

            return services;
        }
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}