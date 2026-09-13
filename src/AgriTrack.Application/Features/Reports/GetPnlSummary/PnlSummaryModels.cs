namespace AgriTrack.Application.Features.Reports.GetPnlSummary;

public sealed record CropProfit(
    Guid CropCycleId,
    string CropTypeName,
    string? CycleLabel,
    DateOnly SownDate,
    decimal TotalExpense,
    decimal TotalIncome,
    decimal Profit);

public sealed record PnlSummaryResponse(decimal TotalIncome, decimal TotalExpense, decimal Profit, IReadOnlyList<CropProfit> PerCrop);
