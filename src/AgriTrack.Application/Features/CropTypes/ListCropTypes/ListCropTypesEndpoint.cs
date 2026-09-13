using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.CropTypes.ListCropTypes;

public static class ListCropTypesEndpoint
{
    public static void MapListCropTypesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/crop-types", async (ListCropTypesHandler handler) =>
        {
            var cropTypes = await handler.HandleAsync();
            return Results.Ok(cropTypes);
        })
        .WithName("ListCropTypes")
        .RequireAuthorization();
    }
}
