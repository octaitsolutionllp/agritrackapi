using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Profile.UpdateLanguage;

public sealed class UpdateLanguageHandler
{
    private readonly IStoredProcRepository _repository;

    public UpdateLanguageHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public Task<User?> HandleAsync(Guid userId, UpdateLanguageRequest request)
    {
        return _repository.QuerySingleOrDefaultAsync<User>(StoredProcedures.UpdateUserLanguage, new
        {
            Id = userId,
            request.PreferredLanguage
        });
    }
}
