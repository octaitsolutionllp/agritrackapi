using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Farms.ListFarms;

public sealed class ListFarmsHandler
{
    private readonly IStoredProcRepository _repository;

    public ListFarmsHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<FarmWithFieldsResponse>> HandleAsync(Guid userId)
    {
        var farmsTask = _repository.QueryAsync<Farm>(StoredProcedures.GetFarmsByUser, new { UserId = userId });
        var fieldsTask = _repository.QueryAsync<Field>(StoredProcedures.GetFieldsByUser, new { UserId = userId });
        await Task.WhenAll(farmsTask, fieldsTask);

        var fieldsByFarm = fieldsTask.Result
            .GroupBy(f => f.FarmId)
            .ToDictionary(g => g.Key, g => g.Select(f => new FieldSummary(f.Id, f.FarmId, f.Name, f.AreaAcres, f.SoilType, f.Location)).ToList());

        return farmsTask.Result
            .Select(farm => new FarmWithFieldsResponse(
                farm.Id,
                farm.Name,
                farm.TotalAreaAcres,
                fieldsByFarm.TryGetValue(farm.Id, out var fields) ? fields : new List<FieldSummary>()))
            .ToList();
    }
}
