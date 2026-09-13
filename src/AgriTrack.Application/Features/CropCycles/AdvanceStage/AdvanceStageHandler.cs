using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.CropCycles.AdvanceStage;

public sealed class AdvanceStageHandler
{
    private readonly IStoredProcRepository _repository;

    public AdvanceStageHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<CropCycle?> HandleAsync(Guid id, Guid userId)
    {
        return _repository.QuerySingleOrDefaultAsync<CropCycle>(StoredProcedures.AdvanceCropCycleStage, new
        {
            Id = id,
            UserId = userId,
            StartedAt = DateOnly.FromDateTime(DateTime.UtcNow)
        });
    }
}
