namespace HouseCostMonitor.Application.Services.Job.Commands.CreateJob;

using HouseCostMonitor.Domain.Enums;

public record CreateJobCommand
{
    public string? Description { get; set; }
    public TimeSpan? Duration { get; set; }
    public JobStatus JobStatus { get; set; }
}