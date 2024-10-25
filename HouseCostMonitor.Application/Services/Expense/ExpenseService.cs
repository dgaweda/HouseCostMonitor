using HouseCostMonitor.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace HouseCostMonitor.Application.Services.Expense;

internal class ExpenseService(IExpenseRepository expenseRepository, ILogger<ExpenseService> logger) : IExpenseService
{
    public async Task<IEnumerable<Domain.Entities.Expense>> GetAllExpenses()
    {
        logger.LogInformation("Getting all expenses");
        return await expenseRepository.GetAllAsync();
    }
}