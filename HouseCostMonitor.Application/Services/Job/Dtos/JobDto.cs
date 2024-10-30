namespace HouseCostMonitor.Application.Services.Job.Dtos;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Enums;

public record JobDto
{
    public Guid Id { get; set; }
    public string Description { get; init; } = default!;
    public TimeSpan? Duration { get; init; }
    public string CreatedBy { get; set; } = default!;
    public JobStatus JobStatus { get; init; }
    public List<ExpenseDto> Expenses { get; init; } = [];
}