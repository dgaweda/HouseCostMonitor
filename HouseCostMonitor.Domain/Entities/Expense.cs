using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class Expense
{
    public Guid Id { get; set; }
    public ExpenseCategory Category { get; set; }
    public string? Description { get; set; }
    public DateTime DateIncurred { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalCost { get; set; }
    public string? Supplier { get; set; }
    public DateTime PurchaseDate { get; set; }
}