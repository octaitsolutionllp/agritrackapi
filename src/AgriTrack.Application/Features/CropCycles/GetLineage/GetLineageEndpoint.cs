using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.CropCycles.GetLineage;

public static class GetLineageEndpoint
{
    public static void MapGetLineageEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/crop-cycles/{id:guid}/lineage", async (Guid id, ClaimsPrincipal user, GetLineageHandler handler) =>
        {
            var lineage = await handler.HandleAsync(id, CurrentUser.GetUserId(user));
            return Results.Ok(lineage);
        })
        .WithName("GetCycleLineage")
        .RequireAuthorization();
    }
}
