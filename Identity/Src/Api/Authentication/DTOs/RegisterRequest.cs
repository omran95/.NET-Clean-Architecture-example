
namespace Identity.Src.Api.Authentication.DTOs;

public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateOnly BirthDate);

