using expert_fiesta.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace expert_fiesta.API.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Er is een exception opgevangen door de middleware: {Message}", exception.Message);
        
        var problemDetails = exception switch
        {
            EmailAlreadyExistsException emailEx => new ProblemDetails()
            {
                Status = StatusCodes.Status409Conflict,
                Title = "E-mailadres al in gebruik",
                Detail = emailEx.Message,
                Instance = httpContext.Request.Path
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Interne Serverfout",
                Detail = "Er is een onverwachte fout opgetreden in de applicatie.",
                Instance = httpContext.Request.Path
            }
        };
        
        httpContext.Response.StatusCode = problemDetails.Status.Value;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}