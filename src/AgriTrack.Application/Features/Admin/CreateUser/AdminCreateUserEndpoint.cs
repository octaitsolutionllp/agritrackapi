using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Admin.CreateUser;

public static class AdminCreateUserEndpoint
{
    public static void MapAdminCreateUserEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/admin/users", async (ClaimsPrincipal admin, AdminCreateUserRequest request, AdminCreateUserHandler handler) =>
        {
            try
            {
                var result = await handler.HandleAsync(CurrentUser.GetUserId(admin), request);
                return Results.Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Results.Conflict(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { message = ex.Message });
            }
        })
        .WithName("AdminCreateUser")
        .RequireAuthorization("AdminOnly");
    }
}
