namespace AgriTrack.Application.Features.Profile.CropSelection;

public sealed record SetCropTypesRequest(IReadOnlyList<Guid> CropTypeIds);
