using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.CropTypes.ListMyCropTypes;

public static class ListMyCropTypesEndpoint
{
    public static void MapListMyCropTypesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/crop-types/mine", async (ClaimsPrincipal user, ListMyCropTypesHandler handler) =>
        {
            var cropTypes = await handler.HandleAsync(CurrentUser.GetUserId(user));
            return Results.Ok(cropTypes);
        })
        .WithName("ListMyCropTypes")
        .RequireAuthorization();
    }
}
