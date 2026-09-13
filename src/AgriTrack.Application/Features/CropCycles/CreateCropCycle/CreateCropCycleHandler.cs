using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.CropCycles.CreateCropCycle;

public sealed class CreateCropCycleHandler
{
    private readonly IStoredProcRepository _repository;

    public CreateCropCycleHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<CropCycle?> HandleAsync(Guid userId, CreateCropCycleRequest request)
    {
        return _repository.QuerySingleOrDefaultAsync<CropCycle>(StoredProcedures.CreateCropCycle, new
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            request.FieldId,
            request.CropTypeId,
            request.SeedVariety,
            request.SownDate,
            request.ExpectedHarvestDate,
            request.CycleLabel,
            request.ParentCropCycleId
        });
    }
}
