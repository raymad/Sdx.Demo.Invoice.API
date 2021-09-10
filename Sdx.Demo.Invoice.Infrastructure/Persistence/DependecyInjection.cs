using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sdx.Demo.Invoice.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Sdx.Demo.Invoice.Infrastructure.Persistence.Entities;
using Sdx.Demo.Invoice.Application.Interfaces;
using Sdx.Demo.Invoice.Infrastructure.Persistence.Services;

namespace Sdx.Demo.Invoice.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var useOracle = configuration.GetValue<bool>("PersistenceSettings:UseOracle");
            var useMsSql = configuration.GetValue<bool>("PersistenceSettings:UseMsSql");
            if (useOracle)
            {
                var connectionString = configuration.GetValue<string>("PersistenceSettings:connectionStrings:oracle");
                services.AddOracle<ApplicationDbContext>(connectionString);
            }
            else if (useMsSql)
            {
                var connectionString = configuration.GetValue<string>("PersistenceSettings:connectionStrings:mssql");
                services.AddMSSQL<ApplicationDbContext>(connectionString);
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IIntegrationEventService, IntegrationEventService>();

            return services;
        }

        private static IServiceCollection AddOracle<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            services.AddDbContext<T>(m => m.UseOracle(connectionString, e => e.MigrationsAssembly(typeof(T).Assembly.FullName)));
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            dbContext.Database.Migrate();
            
            return services;
        }

        // ReSharper disable once InconsistentNaming
        private static IServiceCollection AddMSSQL<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            services.AddDbContext<T>(m => m.UseSqlServer(connectionString, e => e.MigrationsAssembly(typeof(T).Assembly.FullName)));
            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<T>();
            dbContext.Database.Migrate();

            return services;
        }
    }
}
