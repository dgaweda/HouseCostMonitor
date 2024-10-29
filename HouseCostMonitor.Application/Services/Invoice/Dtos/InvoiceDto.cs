namespace HouseCostMonitor.Application.Services.Invoice.Dtos;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Enums;

public record InvoiceDto
{
    public decimal TotalCost { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime DueDate { get; set; }
    public InvoiceStatus InvoiceStatus { get; set; }
    public string? DocumentUrl { get; set; }
    public List<ExpenseDto> Expenses { get; set; } = [];
}