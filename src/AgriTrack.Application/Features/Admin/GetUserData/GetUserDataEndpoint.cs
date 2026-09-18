using AgriTrack.Application.Features.CropCycles.ListCropCycles;
using AgriTrack.Application.Features.Farms.ListFarms;
using AgriTrack.Application.Features.Reports.GetPnlSummary;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Admin.GetUserData;

/// <summary>What an admin sees when drilling into one user — reuses the exact same handlers a
/// user's own Farms/Crop Cycles/Reports screens call, just pointed at the target user's id
/// instead of the caller's own (those handlers were never tied to "current user" internally).</summary>
public sealed record GetUserDataResponse(
    IReadOnlyList<FarmWithFieldsResponse> Farms,
    IEnumerable<AgriTrack.Domain.Entities.CropCycle> CropCycles,
    PnlSummaryResponse Pnl);

public static class GetUserDataEndpoint
{
    public static void MapGetUserDataEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/admin/users/{userId:guid}/data", async (
            Guid userId,
            ListFarmsHandler farmsHandler,
            ListCropCyclesHandler cropCyclesHandler,
            GetPnlSummaryHandler pnlHandler) =>
        {
            var farmsTask = farmsHandler.HandleAsync(userId);
            var cropCyclesTask = cropCyclesHandler.HandleAsync(userId);
            var pnlTask = pnlHandler.HandleAsync(userId);
            await Task.WhenAll(farmsTask, cropCyclesTask, pnlTask);

            return Results.Ok(new GetUserDataResponse(farmsTask.Result, cropCyclesTask.Result, pnlTask.Result));
        })
        .WithName("AdminGetUserData")
        .RequireAuthorization("AdminOnly");
    }
}
