using AgriTrack.Infrastructure;
using ActivityEntity = AgriTrack.Domain.Entities.Activity;

namespace AgriTrack.Application.Features.Activities.ListActivities;

public sealed class ListActivitiesHandler
{
    private readonly IStoredProcRepository _repository;

    public ListActivitiesHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ActivityEntity>> HandleAsync(Guid cropCycleId, Guid userId)
    {
        return _repository.QueryAsync<ActivityEntity>(StoredProcedures.GetActivitiesByCropCycle, new { CropCycleId = cropCycleId, UserId = userId });
    }
}
