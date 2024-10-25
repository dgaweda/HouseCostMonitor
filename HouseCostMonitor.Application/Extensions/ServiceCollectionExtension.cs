using HouseCostMonitor.Application.Services.Expense;
using HouseCostMonitor.Application.Services.Invoice;
using HouseCostMonitor.Application.Services.Job;
using HouseCostMonitor.Application.Services.User;
using HouseCostMonitor.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HouseCostMonitor.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
        
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IUserService, UserService>();
    }
}