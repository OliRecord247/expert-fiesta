using expert_fiesta.API.Features.Customers;
using expert_fiesta.API.Features.Games;
using expert_fiesta.API.Health;
using expert_fiesta.API.Mapping;
using expert_fiesta.API.Middleware;
using expert_fiesta.Application;
using expert_fiesta.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddOpenApi();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddInfrastructure(config["Database:ConnectionString"]!);
builder.Services.AddApplication();
builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>(DatabaseHealthCheck.Name);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
        policy.WithOrigins(allowedOrigins!)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapHealthChecks("_health");

app.UseHttpsRedirection();
app.UseCors();
app.UseMiddleware<ValidationMappingMiddleware>();
app.UseExceptionHandler();
app.UseGameEndpoints();
app.UseCustomerEndpoints();

app.Run();
