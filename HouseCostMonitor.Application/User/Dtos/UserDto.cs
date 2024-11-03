namespace HouseCostMonitor.Application.User.Dtos;

using HouseCostMonitor.Application.Expense.Queries.GetExpenses;
using HouseCostMonitor.Application.Job.Dtos;
using HouseCostMonitor.Domain.Enums;

public record UserDto
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Role Role { get; set; }
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
    public DateTime? LastLoginDate { get; set; }
    public List<JobDto> Jobs { get; set; } = [];
    public List<GetExpensesQuery> Expenses { get; set; } = [];
}