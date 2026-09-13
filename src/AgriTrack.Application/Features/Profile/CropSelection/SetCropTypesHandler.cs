using System.Text.Json;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Profile.CropSelection;

public sealed class SetCropTypesHandler
{
    private readonly IStoredProcRepository _repository;

    public SetCropTypesHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<Guid>> HandleAsync(Guid userId, SetCropTypesRequest request)
    {
        var cropTypeIdsJson = JsonSerializer.Serialize(request.CropTypeIds);
        var ids = await _repository.QueryAsync<Guid>(StoredProcedures.SetUserCropTypes, new { UserId = userId, CropTypeIdsJson = cropTypeIdsJson });
        return ids.ToList();
    }
}
