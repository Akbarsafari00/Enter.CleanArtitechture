using System.Net;
using ApplicationException = Optimum.SharedKernel.Exceptions.ApplicationException;

namespace ECA.Domain.Futures.Users.Exceptions;

public class AuthenticationFailedException : ApplicationException
{
    public AuthenticationFailedException() : base(HttpStatusCode.Unauthorized,"AUTHENTICATION_FAILD", $"authentication failed")
    {
    }
   
}