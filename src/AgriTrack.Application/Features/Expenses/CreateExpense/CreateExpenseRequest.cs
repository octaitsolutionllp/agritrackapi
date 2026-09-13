namespace AgriTrack.Application.Features.Expenses.CreateExpense;

public sealed record CreateExpenseRequest(Guid CropCycleId, string Category, decimal Amount, DateOnly ExpenseDate, string? Notes);
