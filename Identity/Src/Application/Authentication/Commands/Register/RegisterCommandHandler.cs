using ErrorOr;
using Identity.Src.Application.Authentication.Commands.Register;
using Identity.Src.Application.Authentication.DTOs;
using Identity.Src.Domain.Common.contracts;
using Identity.Src.Domain.User;
using MediatR;

namespace Identity.Src.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<Created>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordHashService passwordHashService)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
        }

        public async Task<ErrorOr<Created>> Handle(RegisterCommand command, CancellationToken cancellationToken)
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
            return Result.Created;
        }
    }
}

