namespace HouseCostMonitor.Application.Expense.Commands.EditExpense;

using AutoMapper;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record EditExpenseCommand : IRequest
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

public class EditExpenseCommandHandler(IMapper mapper, IExpenseRepository expenseRepository) : IRequestHandler<EditExpenseCommand>
{
    public async Task Handle(EditExpenseCommand request, CancellationToken cancellationToken)
    {
        var expenseToUpdate = await expenseRepository.GetByIdAsync(request.Id, cancellationToken);
        mapper.Map(request, expenseToUpdate);
        
        await expenseRepository.UpdateAsync(expenseToUpdate, cancellationToken);
    }
}