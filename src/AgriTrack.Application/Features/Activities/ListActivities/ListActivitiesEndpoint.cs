using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Activities.ListActivities;

public static class ListActivitiesEndpoint
{
    public static void MapListActivitiesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/crop-cycles/{cropCycleId:guid}/activities", async (Guid cropCycleId, ClaimsPrincipal user, ListActivitiesHandler handler) =>
        {
            var activities = await handler.HandleAsync(cropCycleId, CurrentUser.GetUserId(user));
            return Results.Ok(activities);
        })
        .WithName("ListActivities")
        .RequireAuthorization();
    }
}
