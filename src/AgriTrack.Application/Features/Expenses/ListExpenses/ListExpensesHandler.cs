using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Expenses.ListExpenses;

public sealed class ListExpensesHandler
{
    private readonly IStoredProcRepository _repository;

    public ListExpensesHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Expense>> HandleAsync(Guid cropCycleId, Guid userId)
    {
        return _repository.QueryAsync<Expense>(StoredProcedures.GetExpensesByCropCycle, new { CropCycleId = cropCycleId, UserId = userId });
    }
}
