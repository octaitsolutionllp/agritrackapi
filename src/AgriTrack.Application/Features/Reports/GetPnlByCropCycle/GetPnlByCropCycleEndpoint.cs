using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Reports.GetPnlByCropCycle;

public static class GetPnlByCropCycleEndpoint
{
    public static void MapGetPnlByCropCycleEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/reports/pnl/{cropCycleId:guid}", async (Guid cropCycleId, ClaimsPrincipal user, GetPnlByCropCycleHandler handler) =>
        {
            var pnl = await handler.HandleAsync(cropCycleId, CurrentUser.GetUserId(user));
            return Results.Ok(pnl);
        })
        .WithName("GetPnlByCropCycle")
        .RequireAuthorization();
    }
}
