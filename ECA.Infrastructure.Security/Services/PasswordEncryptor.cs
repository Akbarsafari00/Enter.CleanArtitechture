using ECA.Application.Abstractions.Services;
using ECA.Application.Abstractions.Services.Security;

namespace ECA.Infrastructure.Security.Services;

public class PasswordEncryptor : IPasswordEncryptor
{
    public string Encrypt(string password)
    {
        // Generate a salt (automatically included in the resulting hash)
        var salt = BCrypt.Net.BCrypt.GenerateSalt();

        // Hash the password using the salt
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

        return hashedPassword;
    }

    public bool Validate(string encryptedPassword, string rawPassword)
    {
        // Use BCrypt to verify the password
        var isValid = BCrypt.Net.BCrypt.Verify(rawPassword, encryptedPassword);
        return isValid;
    }
}