using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Activities.DeleteActivity;

public sealed class DeleteActivityHandler
{
    private readonly IStoredProcRepository _repository;

    public DeleteActivityHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task HandleAsync(Guid id, Guid userId)
    {
        return _repository.ExecuteAsync(StoredProcedures.DeleteActivity, new { Id = id, UserId = userId });
    }
}
