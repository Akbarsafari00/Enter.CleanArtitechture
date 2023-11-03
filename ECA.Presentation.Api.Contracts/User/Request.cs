using ECA.Domain.AggregateModels.UserAggregates;

namespace ECA.Presentation.Api.Contracts.User;

public record CreateUserRequest( string UserName ,
    string Password,
    string FirstName,
    string Lastname,
    UserAddress Address);
