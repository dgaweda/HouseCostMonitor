using HouseCostMonitor.Application.Extensions;
using HouseCostMonitor.Infrastructure.Extensions;

namespace HouseCostMonitor.API;

public static class DependencyInjection
{
    public static void RegisterDI(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
        
        services.AddInfrastructure(config);
        services.AddApplication();
    }

    public static void AddSwagger(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return;
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "HouseCostMonitor API V1");
        });
    }
}