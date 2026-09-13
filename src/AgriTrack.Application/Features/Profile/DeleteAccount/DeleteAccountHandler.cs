using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Profile.DeleteAccount;

public sealed class DeleteAccountHandler
{
    private readonly IStoredProcRepository _repository;

    public DeleteAccountHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(Guid userId, DeleteAccountRequest request)
    {
        var user = await _repository.QuerySingleOrDefaultAsync<User>(StoredProcedures.GetUserById, new { Id = userId });
        if (user is null || !BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Current password is incorrect.");
        }

        await _repository.ExecuteAsync(StoredProcedures.DeleteUserAccount, new { UserId = userId });
    }
}
