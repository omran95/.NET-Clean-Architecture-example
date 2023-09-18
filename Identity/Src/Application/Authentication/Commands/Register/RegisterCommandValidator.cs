using FluentValidation;

namespace Identity.Src.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(command => command.FirstName).NotEmpty();
        RuleFor(command => command.LastName).NotEmpty();
        RuleFor(command => command.Email).NotEmpty().EmailAddress();
        RuleFor(command => command.Password).NotEmpty();
        RuleFor(command => command.BirthDate).NotEmpty().Must(BeOver18);

    }

    protected bool BeOver18(DateOnly birthDate)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        int age = today.Year - birthDate.Year;
        if (age >= 18)
        {
            return true;
        }
        return false;
    }
}

