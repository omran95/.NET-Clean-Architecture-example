using ErrorOr;
using Identity.Src.Application.Authentication.DTOs;
using MediatR;

namespace Identity.Src.Application.Authentication.Queries.Login
{
    public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}