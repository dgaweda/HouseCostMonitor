namespace HouseCostMonitor.Application.Expense.Dtos;

using HouseCostMonitor.Domain.Enums;

public record ExpenseDto
{
    public Guid Id { get; set; }
    public ExpenseType Type { get; init; }
    public string? Description { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
    public string? Supplier { get; init; }
    public DateTime PurchaseDate { get; init; }
    public decimal TotalCost { get; init; }
    public Currency Currency { get; init; }
}