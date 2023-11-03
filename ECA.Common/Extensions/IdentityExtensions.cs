using System.Security.Claims;

namespace ECA.Common.Extensions;

public static class IdentityExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        return Guid.Parse(principal.FindFirst(X => X.Type == ClaimTypes.NameIdentifier).Value);
    }
}