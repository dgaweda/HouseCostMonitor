using HouseCostMonitor.Domain.Entities.Base;
using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class Invoice : BaseEntity
{
    public decimal TotalCost { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime DueDate { get; set; }
    public InvoiceStatus InvoiceStatus { get; set; }
    public string? DocumentUrl { get; set; }

    public List<Expense> Expenses { get; set; } = [];

    public void CalculateTotalCost()
    {
        TotalCost = Expenses.Sum(x => x.TotalCost);
    }
}