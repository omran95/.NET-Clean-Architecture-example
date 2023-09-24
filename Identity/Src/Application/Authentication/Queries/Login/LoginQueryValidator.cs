using FluentValidation;

namespace Identity.Src.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
	public LoginQueryValidator()
	{
        RuleFor(command => command.Email).NotEmpty().EmailAddress();
        RuleFor(command => command.Password).NotEmpty();
    }
}

