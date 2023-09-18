namespace Identity.Src.Application.Authentication.DTOs;

using Src.Domain.User;

public record AuthenticationResult(
    User User,
    string Token);

