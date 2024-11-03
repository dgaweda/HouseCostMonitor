namespace HouseCostMonitor.Application.Services.Expense.Commands.RemoveExpense;

using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record RemoveExpenseCommand(Guid Id) : IRequest<bool>;

public class RemoveExpenseCommandHandler(IExpenseRepository expenseRepository) : IRequestHandler<RemoveExpenseCommand, bool>
{
    public async Task<bool> Handle(RemoveExpenseCommand request, CancellationToken cancellationToken)
    {
        var id = await expenseRepository.DeleteAsync(request.Id, cancellationToken);
        return id is not null;
    }
}