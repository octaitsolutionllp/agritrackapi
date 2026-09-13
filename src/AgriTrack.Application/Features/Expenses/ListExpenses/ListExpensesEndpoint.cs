using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Expenses.ListExpenses;

public static class ListExpensesEndpoint
{
    public static void MapListExpensesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/crop-cycles/{cropCycleId:guid}/expenses", async (Guid cropCycleId, ClaimsPrincipal user, ListExpensesHandler handler) =>
        {
            var expenses = await handler.HandleAsync(cropCycleId, CurrentUser.GetUserId(user));
            return Results.Ok(expenses);
        })
        .WithName("ListExpenses")
        .RequireAuthorization();
    }
}
