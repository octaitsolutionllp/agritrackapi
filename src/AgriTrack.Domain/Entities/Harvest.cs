namespace AgriTrack.Domain.Entities;

public sealed class Harvest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CropCycleId { get; set; }
    public DateOnly HarvestDate { get; set; }
    public decimal? YieldQuantity { get; set; }
    public string? YieldUnit { get; set; }
    public decimal? SaleIncome { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
