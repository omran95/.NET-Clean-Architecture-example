using System;
namespace Identity.Src.Domain.Common.contracts;

public interface IPasswordHashService
{
    string HashPassword(string password);
    bool VerifyPassword(string providedPassword, string hashedPassword);
}

