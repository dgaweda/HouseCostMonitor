namespace HouseCostMonitor.Domain.Entities;

public class JobCategory
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
}