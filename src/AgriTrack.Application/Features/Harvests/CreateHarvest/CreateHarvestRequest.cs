namespace AgriTrack.Application.Features.Harvests.CreateHarvest;

public sealed record CreateHarvestRequest(
    Guid CropCycleId,
    DateOnly HarvestDate,
    decimal? YieldQuantity,
    string? YieldUnit,
    decimal? SaleIncome,
    string? Notes);
