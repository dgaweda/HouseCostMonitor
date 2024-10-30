namespace HouseCostMonitor.Application.Services.Invoice.Validators;

using FluentValidation;
using HouseCostMonitor.Application.Services.Invoice.Dtos;

public class EditInvoiceDtoValidator : AbstractValidator<EditInvoiceDto>
{
    public EditInvoiceDtoValidator()
    {
        RuleFor(dto => dto.IssuedDate)
            .GreaterThan(DateTime.MinValue)
            .WithMessage("Issued Date must be greater then minimal date");

        RuleFor(dto => dto.DueDate)
            .GreaterThan(DateTime.MinValue)
            .WithMessage("Due Date must be greater then minimal date")
            .GreaterThan(dto => dto.IssuedDate)
            .WithMessage("Due Date must be greater than Issue Date");

        RuleFor(dto => dto.DocumentUrl)
            .NotEmpty()
            .WithMessage("DocumentUrl must be filled");
    }
}