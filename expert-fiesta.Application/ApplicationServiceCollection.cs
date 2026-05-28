using expert_fiesta.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace expert_fiesta.Application;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssembly(typeof(IApplicationMarker).Assembly);
        });
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>();
        return services;
    }
}