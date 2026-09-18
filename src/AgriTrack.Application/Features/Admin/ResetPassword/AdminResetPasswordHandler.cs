using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Admin.ResetPassword;

public sealed class AdminResetPasswordHandler
{
    private readonly IStoredProcRepository _repository;

    public AdminResetPasswordHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(Guid targetUserId, AdminResetPasswordRequest request)
    {
        var newPassword = request.NewPassword ?? string.Empty;
        if (newPassword.Length < 6)
        {
            throw new ArgumentException("Password must be at least 6 characters.");
        }

        var target = await _repository.QuerySingleOrDefaultAsync<User>(StoredProcedures.GetUserById, new { Id = targetUserId });
        if (target is null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        var newHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await _repository.ExecuteAsync(StoredProcedures.UpdatePassword, new { Id = targetUserId, PasswordHash = newHash });
    }
}
