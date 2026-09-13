using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.CropCycles.ListCropCycles;

public static class ListCropCyclesEndpoint
{
    public static void MapListCropCyclesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/crop-cycles", async (ClaimsPrincipal user, string? status, ListCropCyclesHandler handler) =>
        {
            var cycles = await handler.HandleAsync(CurrentUser.GetUserId(user), status);
            return Results.Ok(cycles);
        })
        .WithName("ListCropCycles")
        .RequireAuthorization();
    }
}
