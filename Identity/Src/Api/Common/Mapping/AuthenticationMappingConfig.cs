using Identity.Src.Api.Authentication.DTOs;
using Identity.Src.Application.Authentication.Commands.Register;
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
    }
}
