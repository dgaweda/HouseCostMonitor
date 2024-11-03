namespace HouseCostMonitor.Application.Services.Job.Dtos;

public record EditJobCommand
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public TimeSpan? Duration { get; set; }
}