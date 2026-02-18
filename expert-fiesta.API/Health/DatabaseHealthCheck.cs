using expert_fiesta.Application.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace expert_fiesta.API.Health;

public class DatabaseHealthCheck : IHealthCheck
{
    public const string Name = "Database";
    
    private readonly ApplicationDbContext _context;
    private readonly ILogger<DatabaseHealthCheck> _logger;

    public DatabaseHealthCheck(ApplicationDbContext context, ILogger<DatabaseHealthCheck> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
        CancellationToken cancellationToken = new ())
    {
        var isValid = await _context.Database.CanConnectAsync(cancellationToken);
        if (!isValid)
        {
            const string errorMessage = "Database is unhealthy";
            _logger.LogError(errorMessage);
            return HealthCheckResult.Unhealthy(errorMessage);
        }
            
        return HealthCheckResult.Healthy();
    }
}