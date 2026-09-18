using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Admin.SetRole;

public static class SetRoleEndpoint
{
    public static void MapSetRoleEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/api/admin/users/{userId:guid}/role", async (Guid userId, ClaimsPrincipal admin, SetRoleRequest request, SetRoleHandler handler) =>
        {
            try
            {
                var result = await handler.HandleAsync(CurrentUser.GetUserId(admin), userId, request);
                return Results.Ok(result);
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
        .WithName("AdminSetUserRole")
        .RequireAuthorization("AdminOnly");
    }
}
