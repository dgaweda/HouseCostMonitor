using HouseCostMonitor.Domain.Repositories;
using HouseCostMonitor.Infrastructure.Persistence;
using HouseCostMonitor.Infrastructure.Repositories;
using HouseCostMonitor.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseCostMonitor.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("HouseCostMonitorDB");
        services.AddDbContext<HouseCostMonitorDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IHouseCostMonitorDbSeeder, HouseCostMonitorDbSeeder>();
        
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
    }
}