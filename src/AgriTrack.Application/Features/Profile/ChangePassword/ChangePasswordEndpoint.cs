using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Profile.ChangePassword;

public static class ChangePasswordEndpoint
{
    public static void MapChangePasswordEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/api/profile/password", async (ClaimsPrincipal user, ChangePasswordRequest request, ChangePasswordHandler handler) =>
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
        .WithName("ChangePassword")
        .RequireAuthorization();
    }
}
