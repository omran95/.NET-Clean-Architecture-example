namespace Identity.Src.Api.Authentication.DTOs;

public record AuthenticationResponse(
    Guid Id,
    string Name,
    string Email,
    DateOnly BirthDate,
    string Token);

