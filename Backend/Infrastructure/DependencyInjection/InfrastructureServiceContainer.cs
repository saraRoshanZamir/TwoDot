using System.Configuration;
using System.Text;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static class InfrastructureServiceContainer
{
    public static IServiceCollection InfrastructureServices(this IServiceCollection services
        , IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    npgsqlOptions => npgsqlOptions.MigrationsAssembly(
                        typeof(InfrastructureServiceContainer).Assembly.FullName)
                ),
            ServiceLifetime.Scoped);

        return services;
    }
}
