using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Profile.ChangePassword;

public sealed class ChangePasswordHandler
{
    private readonly IStoredProcRepository _repository;

    public ChangePasswordHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(Guid userId, ChangePasswordRequest request)
    {
        var user = await _repository.QuerySingleOrDefaultAsync<User>(StoredProcedures.GetUserById, new { Id = userId });
        if (user is null || !BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Current password is incorrect.");
        }

        var newHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        await _repository.ExecuteAsync(StoredProcedures.UpdatePassword, new { Id = userId, PasswordHash = newHash });
    }
}
