namespace AgriTrack.Domain.Entities;

public sealed class CropType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string StageDurationDaysJson { get; set; } = "{}";
    public string WaterIntervalDaysJson { get; set; } = "{}";
    public string PesticideIntervalDaysJson { get; set; } = "{}";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
