namespace HouseCostMonitor.Application.Services.Job.Dtos;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Enums;

public record JobDto
{
    public string Description { get; set; } = default!;
    public TimeSpan? Duration { get; set; }
    public string CreatedByFirstname { get; set; } = default!;
    public string CreatedByLastname { get; set; } = default!;
    public JobStatus JobStatus { get; set; }
    public List<ExpenseDto> Expenses { get; set; } = [];
}