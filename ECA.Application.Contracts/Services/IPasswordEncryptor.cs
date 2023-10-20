namespace ECA.Application.Contracts.Services;

public interface IPasswordEncryptor
{
    string Encrypt(string password);
    bool Validate(string encryptedPassword , string rawPassword);
}