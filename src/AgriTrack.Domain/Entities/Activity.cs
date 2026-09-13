namespace AgriTrack.Domain.Entities;

public sealed class Activity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CropCycleId { get; set; }
    public string ActivityType { get; set; } = string.Empty; // Water | Pesticide | Fertilizer | Weeding | Other
    public DateOnly ActivityDate { get; set; }
    public decimal? Cost { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
