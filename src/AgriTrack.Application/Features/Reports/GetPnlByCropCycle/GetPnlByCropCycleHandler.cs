using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Reports.GetPnlByCropCycle;

file sealed record PnlTotalsRow(decimal TotalIncome, decimal TotalExpense, decimal Profit);

public sealed class GetPnlByCropCycleHandler
{
    private readonly IStoredProcRepository _repository;

    public GetPnlByCropCycleHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<PnlByCropCycleResponse> HandleAsync(Guid cropCycleId, Guid userId)
    {
        var totalsTask = _repository.QuerySingleOrDefaultAsync<PnlTotalsRow>(
            StoredProcedures.GetPnlByCropCycle, new { CropCycleId = cropCycleId, UserId = userId });
        var breakdownTask = _repository.QueryAsync<CategoryAmount>(
            StoredProcedures.GetExpenseCategoryBreakdown, new { CropCycleId = cropCycleId, UserId = userId });
        await Task.WhenAll(totalsTask, breakdownTask);

        var totals = totalsTask.Result ?? new PnlTotalsRow(0, 0, 0);
        return new PnlByCropCycleResponse(totals.TotalIncome, totals.TotalExpense, totals.Profit, breakdownTask.Result.ToList());
    }
}
