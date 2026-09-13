using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Reports.GetReminders;

public static class GetRemindersEndpoint
{
    public static void MapGetRemindersEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/reports/reminders", async (ClaimsPrincipal user, GetRemindersHandler handler) =>
        {
            var reminders = await handler.HandleAsync(CurrentUser.GetUserId(user));
            return Results.Ok(reminders);
        })
        .WithName("GetReminders")
        .RequireAuthorization();
    }
}
