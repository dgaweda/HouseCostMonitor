namespace HouseCostMonitor.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using HouseCostMonitor.Domain.Entities.Base;

public class House : BaseEntity
{
    [MaxLength(50)]
    public string Name { get; set; } = default!;
    public decimal? HouseSquareFootage { get; set; }
    public Guid? OwnerId { get; set; }
    public User? Owner { get; set; }
    public List<Job> Jobs { get; set; } = [];
}