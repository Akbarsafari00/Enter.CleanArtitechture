using ECA.Domain.AggregateModels.UserAggregates;

namespace ECA.Presentation.Api.Contracts.Auth;

public record AuthLoginRequest( string Username , string Password);
public record AuthRefreshTokenRequest(string RefreshToken);