using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class Report
{
    public Guid Id { get; set; }
    public ReportType Type { get; set; }
    public DateTime GeneratedDate { get; set; }
    public string? FileUrl { get; set; }
}