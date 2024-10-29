namespace HouseCostMonitor.Application.Services.Expense.Dtos;

using HouseCostMonitor.Domain.Enums;

public record AddExpenseDto
{
    public ExpenseType Type { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string? Supplier { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal TotalCost { get; set; }
    public Currency Currency { get; set; }
}