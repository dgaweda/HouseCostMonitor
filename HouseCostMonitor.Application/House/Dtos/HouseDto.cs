namespace HouseCostMonitor.Application.House.Dtos;

using HouseCostMonitor.Application.Job.Dtos;

public record HouseDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Owner { get; set; }
    public decimal? HouseSquareFootage { get; set; }
    public List<JobDto> ToDo { get; set; }
}