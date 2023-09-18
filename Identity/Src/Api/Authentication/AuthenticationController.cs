using Microsoft.AspNetCore.Mvc;
using MediatR;
using MapsterMapper;
using Identity.Src.Api.Authentication.DTOs;
using Identity.Src.Application.Authentication.Commands.Register;
using Identity.Src.Application.Authentication.DTOs;
using Identity.Src.Api.Common;
using ErrorOr;

namespace Identity.Src.Api.Authentication
{
    [Route("auth")]
    public class AuthenicationController : ApiController
    {
        private readonly ISender _bus;
        private readonly IMapper _mapper;

        public AuthenicationController(ISender bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = _mapper.Map<RegisterCommand>(registerRequest);

            ErrorOr<AuthenticationResult> authResult = await _bus.Send(command);

            return authResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)), Problem);
        }
    }
}

