using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Harvests.ListHarvests;

public sealed class ListHarvestsHandler
{
    private readonly IStoredProcRepository _repository;

    public ListHarvestsHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Harvest>> HandleAsync(Guid cropCycleId, Guid userId)
    {
        return _repository.QueryAsync<Harvest>(StoredProcedures.GetHarvestsByCropCycle, new { CropCycleId = cropCycleId, UserId = userId });
    }
}
