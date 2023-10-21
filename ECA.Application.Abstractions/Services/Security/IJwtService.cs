namespace ECA.Application.Abstractions.Services.Security;

public interface IJwtService
{
    string GenerateToken(string userId, IEnumerable<string> roles);
    bool ValidateToken(string token);
}