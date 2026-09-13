using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Expenses.DeleteExpense;

public sealed class DeleteExpenseHandler
{
    private readonly IStoredProcRepository _repository;

    public DeleteExpenseHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task HandleAsync(Guid id, Guid userId)
    {
        return _repository.ExecuteAsync(StoredProcedures.DeleteExpense, new { Id = id, UserId = userId });
    }
}
