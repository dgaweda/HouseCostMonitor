namespace HouseCostMonitor.Application.Services.Expense.Validators;

using FluentValidation;
using HouseCostMonitor.Application.Services.Expense.Dtos;

public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
{
    public CreateExpenseCommandValidator()
    {
        RuleFor(dto => dto.UnitPrice)
            .GreaterThan(0)
            .WithMessage("Unit Price must be greater than zero");
        
        RuleFor(dto => dto.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero");
        
        RuleFor(dto => dto.PurchaseDate)
            .GreaterThan(DateTime.MinValue)
            .WithMessage("Purchase Date must be greater then minimal date");
        
        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Description can't be empty");
    }
}