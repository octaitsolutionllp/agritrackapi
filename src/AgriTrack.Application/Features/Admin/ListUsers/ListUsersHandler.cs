using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Admin.ListUsers;

public sealed class ListUsersHandler
{
    private readonly IStoredProcRepository _repository;

    public ListUsersHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<AdminUserResponse>> HandleAsync()
    {
        var users = await _repository.QueryAsync<User>(StoredProcedures.GetAllUsers);
        return users.Select(AdminUserResponse.From).ToList();
    }
}
