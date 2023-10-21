namespace ECA.Infrastructure.Security.Options;

public class JwtTokenOptions
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpirationMinutes { get; set; }
}