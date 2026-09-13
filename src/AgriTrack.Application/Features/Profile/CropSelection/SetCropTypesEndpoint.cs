using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Profile.CropSelection;

public static class SetCropTypesEndpoint
{
    public static void MapSetCropTypesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/api/profile/crop-types", async (ClaimsPrincipal user, SetCropTypesRequest request, SetCropTypesHandler handler) =>
        {
            var ids = await handler.HandleAsync(CurrentUser.GetUserId(user), request);
            return Results.Ok(ids);
        })
        .WithName("SetCropTypes")
        .RequireAuthorization();
    }
}
