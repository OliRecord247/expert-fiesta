using expert_fiesta.Application;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddOpenApi();
builder.Services.AddDatabase(config["Database:ConnectionString"]!);
builder.Services.AddIdentity();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();