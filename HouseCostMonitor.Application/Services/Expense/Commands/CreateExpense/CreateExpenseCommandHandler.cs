namespace HouseCostMonitor.Application.Services.Expense.Commands.CreateExpense;

using AutoMapper;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record CreateExpenseCommand : IRequest<Guid>
{
    public ExpenseType Type { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? Supplier { get; set; }
    public DateTime PurchaseDate { get; set; }
    public Currency Currency { get; set; }
}

public class CreateExpenseCommandHandler(IMapper mapper, IExpenseRepository expenseRepository) : IRequestHandler<CreateExpenseCommand, Guid>
{
    public async Task<Guid> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var expense = mapper.Map<Expense>(request);
        var id = await expenseRepository.AddAsync(expense, cancellationToken);

        return id;
    }
}