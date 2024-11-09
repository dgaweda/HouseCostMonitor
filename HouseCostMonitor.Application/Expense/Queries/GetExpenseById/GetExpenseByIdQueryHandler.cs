namespace HouseCostMonitor.Application.Expense.Queries.GetExpenseById;

using AutoMapper;
using HouseCostMonitor.Application.Expense.Dtos;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record GetExpenseByIdQuery(Guid Id) : IRequest<ExpenseDto>;

public class GetExpenseByIdQueryHandler(IMapper mapper, IExpenseRepository expenseRepository) : IRequestHandler<GetExpenseByIdQuery, ExpenseDto>
{
    public async Task<ExpenseDto> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var expense = await expenseRepository.GetByIdAsync(request.Id, cancellationToken);
        return mapper.Map<ExpenseDto>(expense);
    }
}