using ErrorOr;
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
        private readonly ICodeGeneratorService _codeGeneratorService;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordHashService passwordHashService, ICodeGeneratorService codeGeneratorService)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _codeGeneratorService = codeGeneratorService;
        }

        public async Task<ErrorOr<Created>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.FindByEmail(command.Email);

            if (user is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            string verificationCode = _codeGeneratorService.generate();
            string hashedPassword = _passwordHashService.HashPassword(command.Password);

            ErrorOr<User> result = User.Create(command.FirstName, command.LastName, command.Email, hashedPassword, command.BirthDate, verificationCode);

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

