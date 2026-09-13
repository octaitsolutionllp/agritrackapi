using System.Security.Claims;
using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Expenses.CreateExpense;

public static class CreateExpenseEndpoint
{
    public static void MapCreateExpenseEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/expenses", async (ClaimsPrincipal user, CreateExpenseRequest request, CreateExpenseHandler handler) =>
        {
            var expense = await handler.HandleAsync(CurrentUser.GetUserId(user), request);
            return Results.Ok(expense);
        })
        .WithName("CreateExpense")
        .RequireAuthorization();
    }
}
