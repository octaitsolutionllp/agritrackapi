using AgriTrack.Infrastructure;
using ActivityEntity = AgriTrack.Domain.Entities.Activity;

namespace AgriTrack.Application.Features.Activities.LogActivity;

public sealed class LogActivityHandler
{
    private readonly IStoredProcRepository _repository;

    public LogActivityHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<ActivityEntity?> HandleAsync(Guid userId, LogActivityRequest request)
    {
        return _repository.QuerySingleOrDefaultAsync<ActivityEntity>(StoredProcedures.LogActivity, new
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            request.CropCycleId,
            request.ActivityType,
            request.ActivityDate,
            request.Cost,
            request.Notes
        });
    }
}
