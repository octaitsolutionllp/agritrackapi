using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.CropCycles.GetLineage;

public sealed class GetLineageHandler
{
    private readonly IStoredProcRepository _repository;

    public GetLineageHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<LineageResponse> HandleAsync(Guid cropCycleId, Guid userId)
    {
        var cycles = (await _repository.QueryAsync<LineageCycle>(
            StoredProcedures.GetCycleLineage, new { CropCycleId = cropCycleId, UserId = userId })).ToList();

        var lifetimeIncome = cycles.Sum(c => c.TotalIncome);
        var lifetimeExpense = cycles.Sum(c => c.TotalExpense);

        return new LineageResponse(cycles, lifetimeIncome, lifetimeExpense, lifetimeIncome - lifetimeExpense);
    }
}
