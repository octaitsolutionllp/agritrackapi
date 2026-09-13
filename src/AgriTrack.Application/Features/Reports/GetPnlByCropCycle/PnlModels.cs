namespace AgriTrack.Application.Features.Reports.GetPnlByCropCycle;

public sealed record CategoryAmount(string Category, decimal Amount);

public sealed record PnlByCropCycleResponse(decimal TotalIncome, decimal TotalExpense, decimal Profit, IReadOnlyList<CategoryAmount> CategoryBreakdown);
