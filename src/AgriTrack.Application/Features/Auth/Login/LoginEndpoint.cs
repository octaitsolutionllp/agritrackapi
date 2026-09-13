using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Auth.Login;

public static class LoginEndpoint
{
    public static void MapLoginEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/login", async (LoginRequest request, LoginHandler handler) =>
        {
            try
            {
                var result = await handler.HandleAsync(request);
                return Results.Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Results.Json(new { message = ex.Message }, statusCode: StatusCodes.Status401Unauthorized);
            }
        })
        .WithName("Login")
        .RequireRateLimiting(RateLimitPolicies.Login)
        .AllowAnonymous();
    }
}
