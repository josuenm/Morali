using Morali.Application.Common.Interfaces;

namespace Morali.Infrastructure.Security;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(password)) return false;
            
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}