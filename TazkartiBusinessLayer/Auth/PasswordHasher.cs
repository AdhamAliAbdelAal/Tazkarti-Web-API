using System.Text;

namespace TazkartiBusinessLayer.Auth;

using Microsoft.AspNetCore.Identity;

public class PasswordHasherUtility
{
    public static string HashPassword(string password)
    {
        var passwordHasher = new PasswordHasher<object>(); // You can replace 'object' with your user type if you have a custom user class

        // Hash the password
        string hashedPassword = passwordHasher.HashPassword(null, password);

        return hashedPassword;
    }

    public static PasswordVerificationResult VerifyPassword(string hashedPassword, string providedPassword)
    {
        var passwordHasher = new PasswordHasher<object>(); // You can replace 'object' with your user type if you have a custom user class

        // Verify the provided password against the hashed password
        var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);

        return result;
    }
}
