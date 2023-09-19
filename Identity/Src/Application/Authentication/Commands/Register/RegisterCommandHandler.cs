using ErrorOr;
using Identity.Src.Application.Authentication.DTOs;
using Identity.Src.Domain.Common.contracts;
using Identity.Src.Domain.User;
using MediatR;

namespace Identity.Src.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordHashService passwordHashService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.FindByEmail(command.Email);
            if (user is not null)
            {
                return Errors.User.DuplicateEmail;
            }
            var hashedPassword = _passwordHashService.HashPassword(command.Password);
            ErrorOr<User> result = User.Create(command.FirstName, command.LastName, command.Email, hashedPassword, command.BirthDate);
            if (result.IsError)
            {
                return result.Errors;
            }
            User newUser = result.Value;
            await _userRepository.Add(newUser);
            var token = _jwtTokenGenerator.Generate(newUser);
            return new AuthenticationResult(
            newUser.UserDescriptor(),
            token);
        }
    }
}

