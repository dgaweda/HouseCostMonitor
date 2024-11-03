namespace HouseCostMonitor.Application.Services.Expense.Queries.GetExpenseById;

using AutoMapper;
using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record GetExpenseByIdQuery(Guid Id) : IRequest<ExpenseDto?>;

public class GetExpenseByIdQueryHandler(IMapper mapper, IExpenseRepository expenseRepository) : IRequestHandler<GetExpenseByIdQuery, ExpenseDto?>
{
    public async Task<ExpenseDto?> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var expense = await expenseRepository.GetByIdAsync(request.Id, cancellationToken);
        return expense is null ? null : mapper.Map<ExpenseDto>(expense);
    }
}