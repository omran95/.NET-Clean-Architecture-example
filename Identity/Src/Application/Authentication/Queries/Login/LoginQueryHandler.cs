using ErrorOr;
using Identity.Src.Application.Authentication.DTOs;
using Identity.Src.Domain.Common.contracts;
using Identity.Src.Domain.User;
using MediatR;

namespace Identity.Src.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userRepository, IPasswordHashService passwordHashService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.FindByEmail(query.Email);

            if (user is null)
            {
                return Errors.User.EmailNotExist;
            }

            if (user.Status == UserStatus.PendingVerification)
            {
                return Errors.User.AccountNotVerified;
            }

            bool isValidPassword = _passwordHashService.VerifyPassword(query.Password, user.Password);

            if (!isValidPassword)
            {
                return Errors.User.InvalidCredentials;
            }

            string authToken = _jwtTokenGenerator.Generate(user);

            return new AuthenticationResult(
            user.UserDescriptor(),
            authToken);

        }
    }
}

