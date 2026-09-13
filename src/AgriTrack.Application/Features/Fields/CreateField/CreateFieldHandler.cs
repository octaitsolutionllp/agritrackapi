using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Fields.CreateField;

public sealed class CreateFieldHandler
{
    private readonly IStoredProcRepository _repository;

    public CreateFieldHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<Field?> HandleAsync(Guid userId, CreateFieldRequest request)
    {
        return _repository.QuerySingleOrDefaultAsync<Field>(StoredProcedures.CreateField, new
        {
            Id = Guid.NewGuid(),
            request.FarmId,
            UserId = userId,
            request.Name,
            request.AreaAcres,
            request.SoilType,
            request.Location
        });
    }
}
