using System.Reflection;
using System.Text;
using ECA.Application.Abstractions.Services.Security;
using ECA.Application.Options;
using ECA.Application.Services;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ECA.Domain;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services )
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddMapster();
        
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