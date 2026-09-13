using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.CropCycles.AdvanceStage;

public static class AdvanceStageEndpoint
{
    public static void MapAdvanceStageEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/crop-cycles/{id:guid}/advance-stage", async (Guid id, ClaimsPrincipal user, AdvanceStageHandler handler) =>
        {
            var cycle = await handler.HandleAsync(id, CurrentUser.GetUserId(user));
            return cycle is null ? Results.NotFound() : Results.Ok(cycle);
        })
        .WithName("AdvanceCropCycleStage")
        .RequireAuthorization();
    }
}
