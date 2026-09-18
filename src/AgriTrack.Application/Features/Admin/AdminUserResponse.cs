using AgriTrack.Domain.Entities;

namespace AgriTrack.Application.Features.Admin;

/// <summary>Shared response shape for every admin user-listing endpoint — deliberately excludes
/// PasswordHash, which the underlying User entity carries but must never leave the server.</summary>
public sealed record AdminUserResponse(
    Guid Id,
    string Name,
    string EmailOrPhone,
    string PreferredLanguage,
    bool HasCompletedCropSelection,
    string Role,
    Guid? CreatedByUserId,
    string? CreatedByName,
    DateTime CreatedAt,
    DateTime UpdatedAt)
{
    public static AdminUserResponse From(User user) => new(
        user.Id, user.Name, user.EmailOrPhone, user.PreferredLanguage, user.HasCompletedCropSelection,
        user.Role, user.CreatedByUserId, user.CreatedByName, user.CreatedAt, user.UpdatedAt);
}
