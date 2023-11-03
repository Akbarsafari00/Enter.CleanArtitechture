using System.Net;
using ApplicationException = Optimum.SharedKernel.Exceptions.ApplicationException;

namespace ECA.Domain.Futures.Users.Exceptions;

public class UserAlreadyExistsException : ApplicationException
{
    public UserAlreadyExistsException(string username) : base(HttpStatusCode.Conflict,"USER_ALREADY_EXCEPTIONS", $"uesr with username: '{username}' already exists")
    {
    }
}