namespace AgriTrack.Domain.Entities;

public sealed class CropCycle
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid FieldId { get; set; }
    public string FieldName { get; set; } = string.Empty;
    public decimal? FieldAreaAcres { get; set; }
    public Guid CropTypeId { get; set; }
    public string CropTypeName { get; set; } = string.Empty;
    public string? SeedVariety { get; set; }
    public DateOnly SownDate { get; set; }
    public DateOnly? ExpectedHarvestDate { get; set; }
    public string CurrentStage { get; set; } = "Sowing";
    public DateOnly StageStartedAt { get; set; }
    public string Status { get; set; } = "Active";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Ratoon/multi-cycle lineage (e.g. sugarcane Lagwad -> Khodva 1 -> Khodva 2).
    public string? CycleLabel { get; set; }
    public Guid? ParentCropCycleId { get; set; }
    public Guid RootCropCycleId { get; set; }

    // Carried along from the CropType join so the reminder engine doesn't need a second round trip.
    public string StageDurationDaysJson { get; set; } = "{}";
    public string WaterIntervalDaysJson { get; set; } = "{}";
    public string PesticideIntervalDaysJson { get; set; } = "{}";
}
