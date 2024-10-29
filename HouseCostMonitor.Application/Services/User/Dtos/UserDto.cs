namespace HouseCostMonitor.Application.Services.User.Dtos;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Application.Services.Job.Dtos;
using HouseCostMonitor.Domain.Enums;

public record UserDto
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Role Role { get; set; }
    public string Firstname { get; set; } = default!;
    public string Lasttname { get; set; } = default!;
    public DateTime? LastLoginDate { get; set; }
    public List<JobDto> Jobs { get; set; } = [];
    public List<ExpenseDto> Expenses { get; set; } = [];
}