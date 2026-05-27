using expert_fiesta.Domain.IRepositories;
using expert_fiesta.Infrastructure.Data;
using expert_fiesta.Infrastructure.Repositories;
using JasperFx;
using Marten;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace expert_fiesta.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddNpgsqlDataSource(connectionString);
        
        services.AddMarten(options =>
        {
            options.DatabaseSchemaName = "other";
            options.AutoCreateSchemaObjects = AutoCreate.All;
        })
        .UseLightweightSessions()
        .UseNpgsqlDataSource();
        
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var dataSource = sp.GetRequiredService<Npgsql.NpgsqlDataSource>();
            options.UseNpgsql(dataSource);
        });
        
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<ICustomerRepository, CustomerDocumentRepository>();
        
        return services;
    }
}