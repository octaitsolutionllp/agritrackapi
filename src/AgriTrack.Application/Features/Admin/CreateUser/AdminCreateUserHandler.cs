using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Admin.CreateUser;

public sealed class AdminCreateUserHandler
{
    private readonly IStoredProcRepository _repository;

    public AdminCreateUserHandler(IStoredProcRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdminUserResponse> HandleAsync(Guid adminUserId, AdminCreateUserRequest request)
    {
        var name = request.Name?.Trim() ?? string.Empty;
        var emailOrPhone = request.EmailOrPhone?.Trim() ?? string.Empty;
        var password = request.Password ?? string.Empty;

        if (name.Length == 0)
        {
            throw new ArgumentException("Name is required.");
        }
        if (emailOrPhone.Length == 0)
        {
            throw new ArgumentException("Email or phone is required.");
        }
        if (password.Length < 6)
        {
            throw new ArgumentException("Password must be at least 6 characters.");
        }

        var existing = await _repository.QuerySingleOrDefaultAsync<User>(
            StoredProcedures.GetUserByEmailOrPhone, new { EmailOrPhone = emailOrPhone });
        if (existing is not null)
        {
            throw new InvalidOperationException("An account with this email or phone already exists.");
        }

        var created = await _repository.QuerySingleOrDefaultAsync<User>(StoredProcedures.CreateUser, new
        {
            Id = Guid.NewGuid(),
            Name = name,
            EmailOrPhone = emailOrPhone,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            request.PreferredLanguage,
            CreatedByUserId = adminUserId
        });

        return AdminUserResponse.From(created!);
    }
}
