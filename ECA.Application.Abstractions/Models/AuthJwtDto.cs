namespace ECA.Application.Futures.Users.Models;

public record AuthJwtDto (string AccessToken ,string RefreshToken ,UserDto User);