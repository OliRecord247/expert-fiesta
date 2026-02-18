using expert_fiesta.API.Features.Games;
using expert_fiesta.API.Mapping;
using expert_fiesta.Application;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddDatabase(config["Database:ConnectionString"]!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<ValidationMappingMiddleware>();
app.UseGameEndpoints();

app.UseHttpsRedirection();

app.Run();
