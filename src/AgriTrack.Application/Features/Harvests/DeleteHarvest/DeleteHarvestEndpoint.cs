using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Harvests.DeleteHarvest;

public static class DeleteHarvestEndpoint
{
    public static void MapDeleteHarvestEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/harvests/{id:guid}", async (Guid id, ClaimsPrincipal user, DeleteHarvestHandler handler) =>
        {
            await handler.HandleAsync(id, CurrentUser.GetUserId(user));
            return Results.NoContent();
        })
        .WithName("DeleteHarvest")
        .RequireAuthorization();
    }
}
