namespace HouseCostMonitor.Application.Services.Invoice.Dtos;

public record EditInvoiceDto
{
    public Guid Id { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime DueDate { get; set; }
    public string? DocumentUrl { get; set; }
}