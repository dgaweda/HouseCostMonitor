namespace HouseCostMonitor.Application.Services.Expense.Commands.EditExpense;

using FluentValidation;

public class EditExpenseCommandValidator : AbstractValidator<EditExpenseCommand>
{
    public EditExpenseCommandValidator()
    {
        RuleFor(dto => dto.UnitPrice)
            .GreaterThan(0)
            .WithMessage("Unit Price must be greater than zero.");
        
        RuleFor(dto => dto.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.");
        
        RuleFor(dto => dto.PurchaseDate)
            .GreaterThan(DateTime.MinValue)
            .WithMessage("Purchase Date must be greater then minimal date");
        
        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Description can't be empty");
    }
}