using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Reports.GetPnlSummary;

public static class GetPnlSummaryEndpoint
{
    public static void MapGetPnlSummaryEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/reports/pnl-summary", async (ClaimsPrincipal user, Guid? farmId, GetPnlSummaryHandler handler) =>
        {
            var summary = await handler.HandleAsync(CurrentUser.GetUserId(user), farmId);
            return Results.Ok(summary);
        })
        .WithName("GetPnlSummary")
        .RequireAuthorization();
    }
}
