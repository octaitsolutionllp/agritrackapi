using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Harvests.ListHarvests;

public static class ListHarvestsEndpoint
{
    public static void MapListHarvestsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/crop-cycles/{cropCycleId:guid}/harvests", async (Guid cropCycleId, ClaimsPrincipal user, ListHarvestsHandler handler) =>
        {
            var harvests = await handler.HandleAsync(cropCycleId, CurrentUser.GetUserId(user));
            return Results.Ok(harvests);
        })
        .WithName("ListHarvests")
        .RequireAuthorization();
    }
}
