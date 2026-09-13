using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Farms.ListFarms;

public static class ListFarmsEndpoint
{
    public static void MapListFarmsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/farms", async (ClaimsPrincipal user, ListFarmsHandler handler) =>
        {
            var farms = await handler.HandleAsync(CurrentUser.GetUserId(user));
            return Results.Ok(farms);
        })
        .WithName("ListFarms")
        .RequireAuthorization();
    }
}
