using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Profile.CropSelection;

public static class GetSelectedCropTypesEndpoint
{
    public static void MapGetSelectedCropTypesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/profile/crop-types", async (ClaimsPrincipal user, GetSelectedCropTypesHandler handler) =>
        {
            var ids = await handler.HandleAsync(CurrentUser.GetUserId(user));
            return Results.Ok(ids);
        })
        .WithName("GetSelectedCropTypes")
        .RequireAuthorization();
    }
}
