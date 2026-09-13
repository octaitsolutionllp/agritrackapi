namespace AgriTrack.Domain.Entities;

public sealed class Expense
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CropCycleId { get; set; }
    public string Category { get; set; } = string.Empty; // Seeds | Fertilizer | Pesticide | Labor | Irrigation | Equipment | Other
    public decimal Amount { get; set; }
    public DateOnly ExpenseDate { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
