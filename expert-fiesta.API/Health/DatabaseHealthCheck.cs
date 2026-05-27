using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;

namespace expert_fiesta.API.Health;

public class DatabaseHealthCheck : IHealthCheck
{
    public const string Name = "Database";
    
    private readonly ILogger<DatabaseHealthCheck> _logger;
    private readonly NpgsqlDataSource _dataSource;

    public DatabaseHealthCheck(ILogger<DatabaseHealthCheck> logger,  NpgsqlDataSource dataSource)
    {
        _logger = logger;
        _dataSource = dataSource;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
        CancellationToken cancellationToken = new ())
    {
        try
        {
            await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
            return HealthCheckResult.Healthy();
        }
        catch (Exception ex)
        {
            const string errorMessage = "Database is unhealthy!";
            _logger.LogError(ex, errorMessage);
            return HealthCheckResult.Unhealthy(errorMessage, ex);
        }
    }
}