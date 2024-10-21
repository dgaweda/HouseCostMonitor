using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    public Guid ExpenseId { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime DueDate { get; set; }
    public Status Status { get; set; }
    public string? DocumentUrl { get; set; }
}