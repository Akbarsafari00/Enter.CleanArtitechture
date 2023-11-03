using System.Net;
using ApplicationException = Optimum.SharedKernel.Exceptions.ApplicationException;

namespace ECA.Domain.Futures.Users.Exceptions;

public class UserNotFoundException : ApplicationException
{
    public UserNotFoundException(Guid id) : base(HttpStatusCode.NotFound,"USER_NOT_FOUND", $"uesr with id: '{id}' not found")
    {
    }
    public UserNotFoundException(string username) : base(HttpStatusCode.NotFound,"USER_NOT_FOUND", $"uesr with username: '{username}' not found")
    {
    }
}