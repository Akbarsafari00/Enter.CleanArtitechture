using ECA.Domain.AggregateModels.UserAggregates;

namespace ECA.Presentation.Api.Contracts.Auth;

public record AuthJwtResponse( string AccessToken , string RefreshToken ,UserResponse User);
