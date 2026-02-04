using expert_fiesta.Application.Data;
using expert_fiesta.Application.Repositories;
using expert_fiesta.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace expert_fiesta.Application;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IGameService, GameService>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(context =>
        {
            context.UseNpgsql(connectionString);
        }, ServiceLifetime.Scoped, ServiceLifetime.Singleton);
        return services;
    }
}