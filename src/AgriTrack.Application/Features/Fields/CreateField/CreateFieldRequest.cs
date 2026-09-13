namespace AgriTrack.Application.Features.Fields.CreateField;

public sealed record CreateFieldRequest(Guid FarmId, string Name, decimal? AreaAcres, string? SoilType, string? Location);
