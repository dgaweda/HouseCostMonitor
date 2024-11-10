
using System.ComponentModel.DataAnnotations.Schema;
using HouseCostMonitor.Domain.Entities.Base;
using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class Job : BaseEntity
{
    public string Description { get; set; } = default!;
    
    [Column(TypeName = "bigint")]
    public TimeSpan? Duration { get; set; }
    public string CreatedBy { get; set; } = default!;
    public JobStatus JobStatus { get; set; }
    
    
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public List<Expense> Expenses { get; set; } = [];

    public void SetJobStatus(JobStatus jobStatus)
    {
        JobStatus = jobStatus;
    }

    public void AddJobExpense(Expense expense)
    {
        Expenses.Add(expense);
    }
}