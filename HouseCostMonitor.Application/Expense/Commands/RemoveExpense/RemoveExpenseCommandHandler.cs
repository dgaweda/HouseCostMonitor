namespace HouseCostMonitor.Application.Expense.Commands.RemoveExpense;

using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record RemoveExpenseCommand(Guid Id) : IRequest;

public class RemoveExpenseCommandHandler(IExpenseRepository expenseRepository) : IRequestHandler<RemoveExpenseCommand>
{
    public async Task Handle(RemoveExpenseCommand request, CancellationToken cancellationToken)
    {
        await expenseRepository.DeleteAsync(request.Id, cancellationToken);
    }
}