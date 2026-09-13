using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.CropCycles.CreateCropCycle;

public static class CreateCropCycleEndpoint
{
    public static void MapCreateCropCycleEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/crop-cycles", async (ClaimsPrincipal user, CreateCropCycleRequest request, CreateCropCycleHandler handler) =>
        {
            var cycle = await handler.HandleAsync(CurrentUser.GetUserId(user), request);
            return Results.Ok(cycle);
        })
        .WithName("CreateCropCycle")
        .RequireAuthorization();
    }
}
