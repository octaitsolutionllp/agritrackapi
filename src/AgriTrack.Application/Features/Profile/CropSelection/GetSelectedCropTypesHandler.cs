using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Profile.CropSelection;

public sealed class GetSelectedCropTypesHandler
{
    private readonly IStoredProcRepository _repository;

    public GetSelectedCropTypesHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<Guid>> HandleAsync(Guid userId)
    {
        var ids = await _repository.QueryAsync<Guid>(StoredProcedures.GetSelectedCropTypeIds, new { UserId = userId });
        return ids.ToList();
    }
}
