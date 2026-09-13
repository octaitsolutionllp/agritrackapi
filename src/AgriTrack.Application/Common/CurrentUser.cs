using System.Security.Claims;

namespace AgriTrack.Application.Common;

/// <summary>Resolves the authenticated user's identity from JWT claims — every handler's only source of "who is asking".</summary>
public static class CurrentUser
{
    public static Guid GetUserId(ClaimsPrincipal user)
    {
        var value = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? throw new InvalidOperationException("Request is missing the user id claim.");
        return Guid.Parse(value);
    }

    public static string GetPreferredLanguage(ClaimsPrincipal user)
    {
        return user.FindFirst("preferred_language")?.Value ?? "en";
    }
}
