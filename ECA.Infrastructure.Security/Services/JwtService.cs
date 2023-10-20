using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECA.Application.Contracts.Services;
using ECA.Infrastructure.Services.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ECA.Infrastructure.ExternalServices;

public class JwtService : IJwtService
{
    private readonly JwtTokenOptions _jwtTokenOptions;

    public JwtService(IOptions<JwtTokenOptions> jwtTokenOptions)
    {
        _jwtTokenOptions = jwtTokenOptions.Value;
    }

    public string GenerateToken(string userId, IEnumerable<string> roles)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var token = new JwtSecurityToken(
            issuer: _jwtTokenOptions.Issuer,
            audience: _jwtTokenOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtTokenOptions.ExpirationMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtTokenOptions.Issuer,
                ValidAudience = _jwtTokenOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.SecretKey)),
                ClockSkew = TimeSpan.Zero // Remove delay of token when expire
            }, out SecurityToken validatedToken);

            return true;
        }
        catch
        {
            return false;
        }
    }
}