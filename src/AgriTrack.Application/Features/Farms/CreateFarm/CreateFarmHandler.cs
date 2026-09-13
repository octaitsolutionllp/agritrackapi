using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Farms.CreateFarm;

public sealed class CreateFarmHandler
{
    private readonly IStoredProcRepository _repository;

    public CreateFarmHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<Farm?> HandleAsync(Guid userId, CreateFarmRequest request)
    {
        return _repository.QuerySingleOrDefaultAsync<Farm>(StoredProcedures.CreateFarm, new
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            request.Name,
            request.TotalAreaAcres
        });
    }
}
