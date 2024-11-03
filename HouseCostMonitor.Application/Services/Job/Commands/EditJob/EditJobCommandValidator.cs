namespace HouseCostMonitor.Application.Services.Job.Validators;

using FluentValidation;
using HouseCostMonitor.Application.Services.Job.Dtos;

public class EditJobCommandValidator : AbstractValidator<EditJobCommand>
{
    public EditJobCommandValidator()
    {
        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Description can't be empty");

        RuleFor(dto => dto.Duration)
            .NotEmpty()
            .WithMessage("Duration can't be empty")
            .GreaterThan(TimeSpan.FromSeconds(0))
            .WithMessage("Duration must be greater than zero");
    }
}