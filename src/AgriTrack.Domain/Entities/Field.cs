namespace AgriTrack.Domain.Entities;

public sealed class Field
{
    public Guid Id { get; set; }
    public Guid FarmId { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal? AreaAcres { get; set; }
    public string? SoilType { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
