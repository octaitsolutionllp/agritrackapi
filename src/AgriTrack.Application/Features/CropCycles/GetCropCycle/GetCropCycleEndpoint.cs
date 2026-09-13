using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.CropCycles.GetCropCycle;

public static class GetCropCycleEndpoint
{
    public static void MapGetCropCycleEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/crop-cycles/{id:guid}", async (Guid id, ClaimsPrincipal user, GetCropCycleHandler handler) =>
        {
            var cycle = await handler.HandleAsync(id, CurrentUser.GetUserId(user));
            return cycle is null ? Results.NotFound() : Results.Ok(cycle);
        })
        .WithName("GetCropCycle")
        .RequireAuthorization();
    }
}
