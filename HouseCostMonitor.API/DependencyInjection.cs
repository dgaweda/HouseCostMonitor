using HouseCostMonitor.Application.Extensions;
using HouseCostMonitor.Infrastructure.Extensions;

namespace HouseCostMonitor.API;

public static class DependencyInjection
{
    public static void RegisterDI(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpContextAccessor();
        
        services.AddInfrastructure(config);
        services.AddApplication();
    }
}