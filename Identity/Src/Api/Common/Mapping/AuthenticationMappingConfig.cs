using Identity.Src.Api.Authentication.DTOs;
using Identity.Src.Application.Authentication.Commands.Register;
using Identity.Src.Application.Authentication.DTOs;
using Identity.Src.Application.Authentication.Queries.Login;
using Mapster;

namespace Identity.Src.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public AuthenticationMappingConfig()
    {
    }
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.UserId.Value.ToString())
            .Map(dest => dest.BirthDate, src => src.User.BirthDate.Value)
            .Map(dest => dest, src => src.User);
    }
}
