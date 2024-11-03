namespace HouseCostMonitor.Application.Services.Expense.Commands.EditExpense;

using AutoMapper;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record EditExpenseCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public ExpenseType Type { get; init; }
    public string? Description { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
    public string? Supplier { get; init; }
    public DateTime PurchaseDate { get; init; }
    public Currency Currency { get; init; }
}

public class EditExpenseCommandHandler(IMapper mapper, IExpenseRepository expenseRepository) : IRequestHandler<EditExpenseCommand, bool>
{
    public async Task<bool> Handle(EditExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = mapper.Map<Expense>(request);
        var expenseToUpdate = await expenseRepository.GetByIdAsync(request.Id, cancellationToken);
        if (expenseToUpdate is null)
            return false;
        
        await expenseRepository.UpdateAsync(expense, cancellationToken);

        return true;
    }
}