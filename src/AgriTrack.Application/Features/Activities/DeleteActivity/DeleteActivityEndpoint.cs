using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Activities.DeleteActivity;

public static class DeleteActivityEndpoint
{
    public static void MapDeleteActivityEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/activities/{id:guid}", async (Guid id, ClaimsPrincipal user, DeleteActivityHandler handler) =>
        {
            await handler.HandleAsync(id, CurrentUser.GetUserId(user));
            return Results.NoContent();
        })
        .WithName("DeleteActivity")
        .RequireAuthorization();
    }
}
