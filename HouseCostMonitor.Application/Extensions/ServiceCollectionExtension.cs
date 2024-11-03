using HouseCostMonitor.Application.Services.Expense;
using HouseCostMonitor.Application.Services.Job;
using HouseCostMonitor.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace HouseCostMonitor.Application.Extensions;

using FluentValidation;
using FluentValidation.AspNetCore;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly)
            .AddFluentValidationAutoValidation();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));
        
        services.AddScoped<IUserService, UserService>();
    }
}