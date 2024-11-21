using Microsoft.Extensions.DependencyInjection;

namespace HouseCostMonitor.Application.Extensions;

using FluentValidation;
using FluentValidation.AspNetCore;
using HouseCostMonitor.Application.User;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly).AddFluentValidationAutoValidation();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));
        
        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();
    }
}