using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.CropCycles.ListCropCycles;

public sealed class ListCropCyclesHandler
{
    private readonly IStoredProcRepository _repository;

    public ListCropCyclesHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<CropCycle>> HandleAsync(Guid userId, string? status = null)
    {
        return _repository.QueryAsync<CropCycle>(StoredProcedures.GetCropCyclesByUser, new { UserId = userId, Status = status });
    }
}
