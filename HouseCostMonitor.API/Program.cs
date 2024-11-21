using HouseCostMonitor.API;
using HouseCostMonitor.API.Middlewares;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.RegisterDependencyInjection(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IHouseCostMonitorDbSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.
app.UseMiddleware<TimeLoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSerilogRequestLogging();
app.AddSwagger();

app.UseHttpsRedirection();

app.MapGroup("api/user")
    .WithTags("User")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
