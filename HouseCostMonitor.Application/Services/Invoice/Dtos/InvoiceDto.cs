namespace HouseCostMonitor.Application.Services.Invoice.Dtos;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Enums;

public record InvoiceDto
{
    public Guid Id { get; set; }
    public decimal TotalCost { get; init; }
    public DateTime IssuedDate { get; init; }
    public DateTime DueDate { get; init; }
    public InvoiceStatus InvoiceStatus { get; init; }
    public string? DocumentUrl { get; init; }
    public List<ExpenseDto> Expenses { get; init; } = [];
}