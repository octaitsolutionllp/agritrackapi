namespace AgriTrack.Application.Features.Auth.Register;

public sealed record RegisterRequest(string Name, string EmailOrPhone, string Password, string PreferredLanguage);

public sealed record AuthResponse(string Token, Guid UserId, string Name, string EmailOrPhone, string PreferredLanguage, bool HasCompletedCropSelection, string Role);
