using HouseCostMonitor.Domain.Entities.Base;
using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

using System.ComponentModel.DataAnnotations;

public class Expense : BaseEntity
{
    public ExpenseType Type { get; set; }
    
    [MaxLength(255)]
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    [MaxLength(100)]
    public string? Supplier { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal TotalCost { get; set; }
    public Currency Currency { get; set; } = Currency.PLN;
    
    public Guid? JobId { get; set; }
    public Job? Job { get; set; }

    public void CalculateTotalCost()
    {
        TotalCost = Quantity * UnitPrice;
    }
}