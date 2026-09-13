using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Profile.DeleteAccount;

public static class DeleteAccountEndpoint
{
    public static void MapDeleteAccountEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/profile/delete-account", async (ClaimsPrincipal user, DeleteAccountRequest request, DeleteAccountHandler handler) =>
        {
            try
            {
                await handler.HandleAsync(CurrentUser.GetUserId(user), request);
                return Results.NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Results.Json(new { message = ex.Message }, statusCode: StatusCodes.Status401Unauthorized);
            }
        })
        .WithName("DeleteAccount")
        .RequireAuthorization();
    }
}
