namespace HouseCostMonitor.Application.Expense.Queries.GetExpenses;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Expense.Dtos;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record GetExpensesQuery : IRequest<IEnumerable<ExpenseDto>>;

public class GetExpensesQueryHandler(IMapper mapper, IExpenseRepository expenseRepository) : IRequestHandler<GetExpensesQuery, IEnumerable<ExpenseDto>>
{
    public async Task<IEnumerable<ExpenseDto>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
    {
        return (await expenseRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<ExpenseDto>(mapper.ConfigurationProvider)
            .ToList();
    }
}