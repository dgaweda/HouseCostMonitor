using System.Text.Json.Serialization;
using HouseCostMonitor.API;
using HouseCostMonitor.API.Middlewares;
using HouseCostMonitor.Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.RegisterDependencyInjection(builder.Configuration);
builder.Host.UseSerilog((context, cfg) => cfg.ReadFrom.Configuration(context.Configuration));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
