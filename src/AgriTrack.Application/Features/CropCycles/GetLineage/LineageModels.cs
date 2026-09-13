namespace AgriTrack.Application.Features.CropCycles.GetLineage;

public sealed record LineageCycle(
    Guid Id,
    Guid? ParentCropCycleId,
    Guid RootCropCycleId,
    string? CycleLabel,
    DateOnly SownDate,
    DateOnly? ExpectedHarvestDate,
    string CurrentStage,
    string Status,
    string CropTypeName,
    string FieldName,
    decimal TotalExpense,
    decimal TotalIncome,
    decimal Profit);

public sealed record LineageResponse(IReadOnlyList<LineageCycle> Cycles, decimal LifetimeIncome, decimal LifetimeExpense, decimal LifetimeProfit);
