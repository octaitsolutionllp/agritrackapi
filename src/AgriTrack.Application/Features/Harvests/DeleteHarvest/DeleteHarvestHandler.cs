using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Harvests.DeleteHarvest;

public sealed class DeleteHarvestHandler
{
    private readonly IStoredProcRepository _repository;

    public DeleteHarvestHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task HandleAsync(Guid id, Guid userId)
    {
        return _repository.ExecuteAsync(StoredProcedures.DeleteHarvest, new { Id = id, UserId = userId });
    }
}
