
namespace HouseCostMonitor.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<Guid>
{
    [MaxLength(255)]
    public string? Firstname { get; set; } = default!;
    
    [MaxLength(255)]
    public string? Lastname { get; set; } = default!;
    public DateOnly? DateOfBirth { get; set; }
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