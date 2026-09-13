using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Harvests.CreateHarvest;

public static class CreateHarvestEndpoint
{
    public static void MapCreateHarvestEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/harvests", async (ClaimsPrincipal user, CreateHarvestRequest request, CreateHarvestHandler handler) =>
        {
            var harvest = await handler.HandleAsync(CurrentUser.GetUserId(user), request);
            return Results.Ok(harvest);
        })
        .WithName("CreateHarvest")
        .RequireAuthorization();
    }
}
