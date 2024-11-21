using HouseCostMonitor.Domain.Repositories;
using HouseCostMonitor.Infrastructure.Persistence;
using HouseCostMonitor.Infrastructure.Repositories;
using HouseCostMonitor.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseCostMonitor.Infrastructure.Extensions;

using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("HouseCostMonitorDB");
        services.AddDbContext<HouseCostMonitorDbContext>(options => options
            .UseSqlServer(connectionString)
            .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<Role>()
            .AddEntityFrameworkStores<HouseCostMonitorDbContext>();

        services.AddScoped<IUserRoleStore<User>, UserStore<User, Role, HouseCostMonitorDbContext, Guid>>();
        services.AddScoped<IHouseCostMonitorDbSeeder, HouseCostMonitorDbSeeder>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
    }
}