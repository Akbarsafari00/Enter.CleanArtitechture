using System.Text;
using ECA.Application.Abstractions.Services.Security;
using ECA.Infrastructure.Security.Options;
using ECA.Infrastructure.Security.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
namespace ECA.Infrastructure.IoC;

public static class SecurityExtensions
{
    public static IServiceCollection AddEcaSecurityPasswordEncryptor(this IServiceCollection services )
    {
        services.AddSingleton<IPasswordEncryptor, PasswordEncryptor>();
        return services;
    }
    
    public static IServiceCollection AddEcaSecurityJwtAuthentication(this IServiceCollection services )
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        
        // Configure Core Options
        var jwtTokenOptions = configuration.GetSection("Jwt").Get<JwtTokenOptions>();

        if (jwtTokenOptions == null)
            throw new ArgumentNullException(nameof(jwtTokenOptions));
        
        services.AddSingleton(jwtTokenOptions);
        services.AddSingleton<IJwtService,JwtService>();
        
        var key = Encoding.ASCII.GetBytes(jwtTokenOptions.SecretKey);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtTokenOptions.Issuer,
                    ValidAudience = jwtTokenOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero // Remove delay of token when expire
                };
            });
        return services;
    }
}