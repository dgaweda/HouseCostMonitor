namespace HouseCostMonitor.Application.Services.Job.Validators;

using FluentValidation;
using HouseCostMonitor.Application.Services.Job.Dtos;

public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
{
    public CreateJobCommandValidator()
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