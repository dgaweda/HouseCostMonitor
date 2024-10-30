using HouseCostMonitor.Domain.Entities.Base;
using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Role Role { get; set; }
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
    public DateTime? LastLoginDate { get; set; }

    public List<Job> Jobs { get; set; } = [];
    public List<Expense> Expenses { get; set; } = [];

    public void AddJobs(IEnumerable<Job> jobs)
    {
        Jobs.AddRange(jobs);
    }
    
    public void AddExpenses(IEnumerable<Expense> expenses)
    {
        Expenses.AddRange(expenses);
    }

    public void RemoveUserJobs(IEnumerable<Guid> jobIds)
    {
        Jobs.RemoveAll(job => jobIds.Contains(job.Id));
    }
    
    public void RemoveUserExpenses(IEnumerable<Guid> expenseIds)
    {
        Expenses.RemoveAll(job => expenseIds.Contains(job.Id));
    }
}