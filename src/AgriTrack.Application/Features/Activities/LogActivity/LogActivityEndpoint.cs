using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Activities.LogActivity;

public static class LogActivityEndpoint
{
    public static void MapLogActivityEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/activities", async (ClaimsPrincipal user, LogActivityRequest request, LogActivityHandler handler) =>
        {
            var activity = await handler.HandleAsync(CurrentUser.GetUserId(user), request);
            return Results.Ok(activity);
        })
        .WithName("LogActivity")
        .RequireAuthorization();
    }
}
