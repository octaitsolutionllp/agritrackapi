using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Farms.CreateFarm;

public static class CreateFarmEndpoint
{
    public static void MapCreateFarmEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/farms", async (ClaimsPrincipal user, CreateFarmRequest request, CreateFarmHandler handler) =>
        {
            var farm = await handler.HandleAsync(CurrentUser.GetUserId(user), request);
            return Results.Ok(farm);
        })
        .WithName("CreateFarm")
        .RequireAuthorization();
    }
}
