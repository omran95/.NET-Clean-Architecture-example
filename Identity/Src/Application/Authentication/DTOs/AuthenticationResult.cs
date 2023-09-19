namespace Identity.Src.Application.Authentication.DTOs;

using Src.Domain.User.ValueObjects;

public record AuthenticationResult(
    UserDescriptor User,
    string Token);

