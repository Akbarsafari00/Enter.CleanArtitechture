namespace ECA.Application.Abstractions.Services.Security;

public interface IPasswordEncryptor
{
    string Encrypt(string password);
    bool Validate(string encryptedPassword , string rawPassword);
}