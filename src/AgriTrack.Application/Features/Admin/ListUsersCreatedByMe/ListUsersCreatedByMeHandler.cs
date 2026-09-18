using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Admin.ListUsersCreatedByMe;

public sealed class ListUsersCreatedByMeHandler
{
    private readonly IStoredProcRepository _repository;

    public ListUsersCreatedByMeHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<AdminUserResponse>> HandleAsync(Guid adminUserId)
    {
        var users = await _repository.QueryAsync<User>(StoredProcedures.GetUsersCreatedByAdmin, new { AdminUserId = adminUserId });
        return users.Select(AdminUserResponse.From).ToList();
    }
}
