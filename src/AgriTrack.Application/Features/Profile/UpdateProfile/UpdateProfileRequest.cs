namespace AgriTrack.Application.Features.Profile.UpdateProfile;

public sealed record UpdateProfileRequest(string Name, string EmailOrPhone);

public sealed record UpdateProfileResponse(Guid Id, string Name, string EmailOrPhone, string PreferredLanguage);
