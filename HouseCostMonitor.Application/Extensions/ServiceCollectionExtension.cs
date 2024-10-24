using HouseCostMonitor.Application.Expense;
using HouseCostMonitor.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HouseCostMonitor.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IExpenseService, ExpenseService>();
    }
}