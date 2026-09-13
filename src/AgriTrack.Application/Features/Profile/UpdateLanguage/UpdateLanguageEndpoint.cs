using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Profile.UpdateLanguage;

public static class UpdateLanguageEndpoint
{
    public static void MapUpdateLanguageEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/api/profile/language", async (ClaimsPrincipal user, UpdateLanguageRequest request, UpdateLanguageHandler handler) =>
        {
            var updated = await handler.HandleAsync(CurrentUser.GetUserId(user), request);
            return Results.Ok(updated);
        })
        .WithName("UpdateLanguage")
        .RequireAuthorization();
    }
}
