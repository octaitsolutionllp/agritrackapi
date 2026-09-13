using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Harvests.CreateHarvest;

public sealed class CreateHarvestHandler
{
    private readonly IStoredProcRepository _repository;

    public CreateHarvestHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<Harvest?> HandleAsync(Guid userId, CreateHarvestRequest request)
    {
        return _repository.QuerySingleOrDefaultAsync<Harvest>(StoredProcedures.CreateHarvest, new
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            request.CropCycleId,
            request.HarvestDate,
            request.YieldQuantity,
            request.YieldUnit,
            request.SaleIncome,
            request.Notes
        });
    }
}
