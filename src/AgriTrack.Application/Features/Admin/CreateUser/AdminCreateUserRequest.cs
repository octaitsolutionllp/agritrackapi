namespace AgriTrack.Application.Features.Admin.CreateUser;

public sealed record AdminCreateUserRequest(string Name, string EmailOrPhone, string Password, string PreferredLanguage);
