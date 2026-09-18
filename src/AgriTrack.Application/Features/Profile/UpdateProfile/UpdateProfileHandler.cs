using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Profile.UpdateProfile;

public sealed class UpdateProfileHandler
{
    private readonly IStoredProcRepository _repository;

    public UpdateProfileHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateProfileResponse> HandleAsync(Guid userId, UpdateProfileRequest request)
    {
        var name = request.Name?.Trim() ?? string.Empty;
        var emailOrPhone = request.EmailOrPhone?.Trim() ?? string.Empty;

        if (name.Length == 0)
        {
            throw new ArgumentException("Name is required.");
        }
        if (emailOrPhone.Length == 0)
        {
            throw new ArgumentException("Email or phone is required.");
        }

        var existing = await _repository.QuerySingleOrDefaultAsync<User>(
            StoredProcedures.GetUserByEmailOrPhone, new { EmailOrPhone = emailOrPhone });
        if (existing is not null && existing.Id != userId)
        {
            throw new InvalidOperationException("Another account is already using this email or phone.");
        }

        var updated = await _repository.QuerySingleOrDefaultAsync<User>(
            StoredProcedures.UpdateUserProfile, new { Id = userId, Name = name, EmailOrPhone = emailOrPhone });
        if (updated is null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        return new UpdateProfileResponse(updated.Id, updated.Name, updated.EmailOrPhone, updated.PreferredLanguage);
    }
}
