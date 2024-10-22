using HouseCostMonitor.Domain.Entities.Base;
using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class Expense : BaseEntity
{
    public ExpenseType Type { get; set; }
    public string? Description { get; set; }
    public DateTime DateIncurred { get; set; }
    public Guid CreatedBy { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalCost { get; set; }
    public string? Supplier { get; set; }
    public DateTime PurchaseDate { get; set; }
    
    public Guid? JobId { get; set; }
    public Guid? InvoiceId { get; set; }
}