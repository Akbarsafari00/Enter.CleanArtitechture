namespace ECA.Application.Contracts.Services;

public interface IJwtService
{
    string GenerateToken(string userId, IEnumerable<string> roles);
    bool ValidateToken(string token);
}