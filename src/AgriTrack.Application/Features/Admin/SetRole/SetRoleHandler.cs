using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Admin.SetRole;

public sealed class SetRoleHandler
{
    private static readonly string[] ValidRoles = ["User", "Admin"];

    private readonly IStoredProcRepository _repository;

    public SetRoleHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdminUserResponse> HandleAsync(Guid adminUserId, Guid targetUserId, SetRoleRequest request)
    {
        if (!ValidRoles.Contains(request.Role))
        {
            throw new ArgumentException("Role must be 'User' or 'Admin'.");
        }
        if (targetUserId == adminUserId)
        {
            throw new ArgumentException("You cannot change your own role.");
        }

        var updated = await _repository.QuerySingleOrDefaultAsync<User>(
            StoredProcedures.SetUserRole, new { UserId = targetUserId, request.Role });
        if (updated is null)
        {
            throw new KeyNotFoundException("User not found.");
        }

        return AdminUserResponse.From(updated);
    }
}
