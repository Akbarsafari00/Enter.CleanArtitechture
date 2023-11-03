using ECA.Domain.AggregateModels.UserAggregates;

namespace ECA.Presentation.Api.Contracts.Auth;

public record UserResponse(
    Guid Id,
    string Username,
    string FirstName,
    string LastName,
    string Status,
    int StatusId,
    UserAddress Address
    );
