namespace AgriTrack.Application.Features.Farms.ListFarms;

public sealed record FieldSummary(Guid Id, Guid FarmId, string Name, decimal? AreaAcres, string? SoilType, string? Location);

public sealed record FarmWithFieldsResponse(Guid Id, string Name, decimal? TotalAreaAcres, IReadOnlyList<FieldSummary> Fields);
