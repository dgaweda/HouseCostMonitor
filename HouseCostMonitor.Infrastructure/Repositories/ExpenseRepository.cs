using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Repositories;
using HouseCostMonitor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseCostMonitor.Infrastructure.Repositories;

internal class ExpenseRepository(HouseCostMonitorDbContext dbContext) : IExpenseRepository
{
    public async Task<IEnumerable<Expense>> GetAllAsync()
    {
        var expenses = await dbContext.Expenses.ToListAsync();
        return expenses;
    }
}