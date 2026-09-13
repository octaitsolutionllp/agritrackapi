using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.CropCycles.GetCropCycle;

public sealed class GetCropCycleHandler
{
    private readonly IStoredProcRepository _repository;

    public GetCropCycleHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<CropCycle?> HandleAsync(Guid id, Guid userId)
    {
        return _repository.QuerySingleOrDefaultAsync<CropCycle>(StoredProcedures.GetCropCycleById, new { Id = id, UserId = userId });
    }
}
