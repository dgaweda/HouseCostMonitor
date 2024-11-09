using HouseCostMonitor.Application.Extensions;
using HouseCostMonitor.Infrastructure.Extensions;

namespace HouseCostMonitor.API;

using HouseCostMonitor.API.Middlewares;

public static class DependencyInjection
{
    public static void RegisterDependencyInjection(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<ErrorHandlingMiddleware>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
        
        services.AddInfrastructure(config);
        services.AddApplication();
    }

    public static void UseSwagger(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "HouseCostMonitor API V1");
        });
    }
}