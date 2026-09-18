using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Admin.ListUsersCreatedByMe;

public static class ListUsersCreatedByMeEndpoint
{
    public static void MapListUsersCreatedByMeEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/admin/users/created-by-me", async (ClaimsPrincipal user, ListUsersCreatedByMeHandler handler) =>
        {
            var result = await handler.HandleAsync(CurrentUser.GetUserId(user));
            return Results.Ok(result);
        })
        .WithName("AdminListUsersCreatedByMe")
        .RequireAuthorization("AdminOnly");
    }
}
