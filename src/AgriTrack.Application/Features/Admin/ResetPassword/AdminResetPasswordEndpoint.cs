using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Admin.ResetPassword;

public static class AdminResetPasswordEndpoint
{
    public static void MapAdminResetPasswordEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/admin/users/{userId:guid}/reset-password", async (Guid userId, AdminResetPasswordRequest request, AdminResetPasswordHandler handler) =>
        {
            try
            {
                await handler.HandleAsync(userId, request);
                return Results.NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return Results.NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { message = ex.Message });
            }
        })
        .WithName("AdminResetPassword")
        .RequireAuthorization("AdminOnly");
    }
}
