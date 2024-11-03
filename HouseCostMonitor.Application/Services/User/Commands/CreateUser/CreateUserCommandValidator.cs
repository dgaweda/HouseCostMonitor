namespace HouseCostMonitor.Application.Services.User.Validators;

using FluentValidation;
using HouseCostMonitor.Application.Services.User.Dtos;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(dto => dto.Username)
            .NotEmpty()
            .WithMessage("Username can't be empty")
            .Length(5, 50)
            .WithMessage("Username must be minimum 5 characters and maximu 50 characters length");

        RuleFor(dto => dto.Email)
            .EmailAddress()
            .WithMessage("Provide correct email address");

        RuleFor(dto => dto.Firstname)
            .NotEmpty()
            .WithMessage("Firstname can't be empty")
            .Length(5, 50)
            .WithMessage("Firstname must be minimum 5 characters and maximu 50 characters length");
        
        RuleFor(dto => dto.Lastname)
            .NotEmpty()
            .WithMessage("Lastname can't be empty")
            .Length(5, 50)
            .WithMessage("Lastname must be minimum 5 characters and maximu 50 characters length");
    }
}