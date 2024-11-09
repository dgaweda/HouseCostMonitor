namespace HouseCostMonitor.Application.Job.Commands.AddJobExpense;

using AutoMapper;
using HouseCostMonitor.Application.Expense.Commands.CreateExpense;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record AddJobExpenseCommand : IRequest
{
    public Guid JobId { get; set; }
    public CreateExpenseCommand CreateExpenseCommand { get; set; }
}

public class AddJobExpenseCommandHandler(IMapper mapper, IJobRepository jobRepository) : IRequestHandler<AddJobExpenseCommand>
{
    public async Task Handle(AddJobExpenseCommand request, CancellationToken cancellationToken)
    {
        var job = await jobRepository.GetByIdAsync(request.JobId, cancellationToken);
        
        var expense = mapper.Map<Expense>(request.CreateExpenseCommand);
        job.AddJobExpense(expense);

        await jobRepository.UpdateAsync(job, cancellationToken);
    }
}