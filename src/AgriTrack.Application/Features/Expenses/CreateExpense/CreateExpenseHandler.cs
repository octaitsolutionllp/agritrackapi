using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Expenses.CreateExpense;

public sealed class CreateExpenseHandler
{
    private readonly IStoredProcRepository _repository;

    public CreateExpenseHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<Expense?> HandleAsync(Guid userId, CreateExpenseRequest request)
    {
        return _repository.QuerySingleOrDefaultAsync<Expense>(StoredProcedures.CreateExpense, new
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            request.CropCycleId,
            request.Category,
            request.Amount,
            request.ExpenseDate,
            request.Notes
        });
    }
}
