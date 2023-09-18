namespace Identity.Src.Domain.Common.contracts;
using Identity.Src.Domain.User;

public interface IJwtTokenGenerator
{
    string Generate(User user);
}

