
namespace HouseCostMonitor.Domain.Entities;

public class RemainingJob
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public TimeSpan EstimatedTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
    public string CreatedBy { get; set; }
}