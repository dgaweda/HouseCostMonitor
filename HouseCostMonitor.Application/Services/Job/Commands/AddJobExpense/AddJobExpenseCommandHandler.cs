namespace HouseCostMonitor.Application.Services.Job.Commands.AddJobExpense;

using AutoMapper;
using HouseCostMonitor.Application.Services.Expense.Commands.CreateExpense;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record AddJobExpenseCommand : IRequest<bool>
{
    public Guid JobId { get; set; }
    public CreateExpenseCommand CreateExpenseCommand { get; set; }
}

public class AddJobExpenseCommandHandler(IMapper mapper, IJobRepository jobRepository) : IRequestHandler<AddJobExpenseCommand, bool>
{
    public async Task<bool> Handle(AddJobExpenseCommand request, CancellationToken cancellationToken)
    {
        var job = await jobRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job is null)
            return false;
        
        var expense = mapper.Map<Expense>(request.CreateExpenseCommand);
        job.AddJobExpense(expense);

        await jobRepository.UpdateAsync(job, cancellationToken);
        return true;
    }
}