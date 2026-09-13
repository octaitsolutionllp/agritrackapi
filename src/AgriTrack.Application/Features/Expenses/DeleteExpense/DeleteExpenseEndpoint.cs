using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Expenses.DeleteExpense;

public static class DeleteExpenseEndpoint
{
    public static void MapDeleteExpenseEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/expenses/{id:guid}", async (Guid id, ClaimsPrincipal user, DeleteExpenseHandler handler) =>
        {
            await handler.HandleAsync(id, CurrentUser.GetUserId(user));
            return Results.NoContent();
        })
        .WithName("DeleteExpense")
        .RequireAuthorization();
    }
}
