namespace AgriTrack.Application.Features.Activities.LogActivity;

public sealed record LogActivityRequest(Guid CropCycleId, string ActivityType, DateOnly ActivityDate, decimal? Cost, string? Notes);
