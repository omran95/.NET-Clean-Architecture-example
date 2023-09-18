using Identity.Src.Domain.Common.contracts;
namespace Identity.Src.Infrastructure.Services;

public class PasswordHashService : IPasswordHashService
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());

    public bool VerifyPassword(string providedPassword, string hashedPassword) => BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
}

