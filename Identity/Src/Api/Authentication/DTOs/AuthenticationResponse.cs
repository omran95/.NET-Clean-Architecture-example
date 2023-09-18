namespace Identity.Src.Api.Authentication.DTOs;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);

