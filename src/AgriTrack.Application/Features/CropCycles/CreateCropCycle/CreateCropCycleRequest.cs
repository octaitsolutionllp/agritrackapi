namespace AgriTrack.Application.Features.CropCycles.CreateCropCycle;

public sealed record CreateCropCycleRequest(
    Guid FieldId,
    Guid CropTypeId,
    string? SeedVariety,
    DateOnly SownDate,
    DateOnly? ExpectedHarvestDate,
    string? CycleLabel = null,
    Guid? ParentCropCycleId = null);
