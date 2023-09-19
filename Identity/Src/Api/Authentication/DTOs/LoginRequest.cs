namespace Identity.Src.Api.Authentication.DTOs;

public record LoginRequest
(
    string Email,
    string Password);

