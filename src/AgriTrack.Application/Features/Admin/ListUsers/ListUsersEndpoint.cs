using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Admin.ListUsers;

public static class ListUsersEndpoint
{
    public static void MapListUsersEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/admin/users", async (ListUsersHandler handler) =>
        {
            var result = await handler.HandleAsync();
            return Results.Ok(result);
        })
        .WithName("AdminListUsers")
        .RequireAuthorization("AdminOnly");
    }
}
