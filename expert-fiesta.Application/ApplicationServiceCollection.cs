using expert_fiesta.Application.Data;
using expert_fiesta.Application.Domain;
using expert_fiesta.Application.Repositories;
using expert_fiesta.Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace expert_fiesta.Application;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IGameService, GameService>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(context =>
        {
            context.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        }, ServiceLifetime.Scoped, ServiceLifetime.Singleton);
        return services;
    }

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
        return services;
    }
}