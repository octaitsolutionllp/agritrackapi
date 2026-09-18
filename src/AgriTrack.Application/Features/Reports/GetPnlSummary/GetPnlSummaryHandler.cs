using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Reports.GetPnlSummary;

file sealed record PnlTotalsRow(decimal TotalIncome, decimal TotalExpense, decimal Profit);

public sealed class GetPnlSummaryHandler
{
    private readonly IStoredProcRepository _repository;

    public GetPnlSummaryHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<PnlSummaryResponse> HandleAsync(Guid userId, Guid? farmId = null, Guid? fieldId = null)
    {
        var totalsTask = _repository.QuerySingleOrDefaultAsync<PnlTotalsRow>(StoredProcedures.GetPnlSummaryByUser, new { UserId = userId, FarmId = farmId, FieldId = fieldId });
        var perCropTask = _repository.QueryAsync<CropProfit>(StoredProcedures.GetPnlByCropForUser, new { UserId = userId, FarmId = farmId, FieldId = fieldId });
        await Task.WhenAll(totalsTask, perCropTask);

        var totals = totalsTask.Result ?? new PnlTotalsRow(0, 0, 0);
        return new PnlSummaryResponse(totals.TotalIncome, totals.TotalExpense, totals.Profit, perCropTask.Result.ToList());
    }
}
