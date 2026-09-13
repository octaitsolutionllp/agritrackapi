using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Fields.CreateField;

public static class CreateFieldEndpoint
{
    public static void MapCreateFieldEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/fields", async (ClaimsPrincipal user, CreateFieldRequest request, CreateFieldHandler handler) =>
        {
            var field = await handler.HandleAsync(CurrentUser.GetUserId(user), request);
            return Results.Ok(field);
        })
        .WithName("CreateField")
        .RequireAuthorization();
    }
}
