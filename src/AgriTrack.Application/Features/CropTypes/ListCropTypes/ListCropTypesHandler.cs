using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.CropTypes.ListCropTypes;

public sealed class ListCropTypesHandler
{
    private readonly IStoredProcRepository _repository;

    public ListCropTypesHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<CropType>> HandleAsync()
    {
        return _repository.QueryAsync<CropType>(StoredProcedures.GetCropTypes);
    }
}
