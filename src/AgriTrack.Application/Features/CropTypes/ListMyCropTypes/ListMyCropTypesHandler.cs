using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.CropTypes.ListMyCropTypes;

public sealed class ListMyCropTypesHandler
{
    private readonly IStoredProcRepository _repository;

    public ListMyCropTypesHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<CropType>> HandleAsync(Guid userId)
    {
        return _repository.QueryAsync<CropType>(StoredProcedures.GetMyCropTypes, new { UserId = userId });
    }
}
