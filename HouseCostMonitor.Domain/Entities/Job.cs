
using HouseCostMonitor.Domain.Entities.Base;
using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class Job : BaseEntity
{
    public string Description { get; set; }
    public TimeSpan EstimatedTime { get; set; }
    public string CreatedBy { get; set; }
    public JobStatus JobStatus { get; set; }
    public Guid? UserId { get; set; }
    public List<Expense> Expenses { get; set; } = [];
}