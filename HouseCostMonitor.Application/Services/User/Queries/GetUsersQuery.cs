namespace HouseCostMonitor.Application.Services.User.Dtos;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Application.Services.Job.Dtos;
using HouseCostMonitor.Domain.Enums;

public record GetUsersQuery
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Role Role { get; set; }
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
    public DateTime? LastLoginDate { get; set; }
    public List<GetJobsQuery> Jobs { get; set; } = [];
    public List<GetExpenseQuery> Expenses { get; set; } = [];
}