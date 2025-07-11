using Microsoft.AspNetCore.Identity;

namespace BaileFunk.Services;

public class PasswordService
{
    private readonly PasswordHasher<object> passwordHasher;

    public PasswordService()
    {
        passwordHasher = new PasswordHasher<object>();
    }

    public string HashPassword(string password)
    {
        var hashedPassword = passwordHasher.HashPassword(null, password);

        return hashedPassword;
    }
    
    public bool VerifyPassword(string hashedPassword, string password)
    {
        var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}