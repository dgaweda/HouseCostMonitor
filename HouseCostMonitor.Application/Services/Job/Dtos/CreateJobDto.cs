namespace HouseCostMonitor.Application.Services.Job.Dtos;

using HouseCostMonitor.Domain.Enums;

public record CreateJobDto
{
    public string? Description { get; set; }
    public TimeSpan? Duration { get; set; }
    public JobStatus JobStatus { get; set; }
}