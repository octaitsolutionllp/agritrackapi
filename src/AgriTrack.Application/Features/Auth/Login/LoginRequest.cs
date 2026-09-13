namespace AgriTrack.Application.Features.Auth.Login;

public sealed record LoginRequest(string EmailOrPhone, string Password, string CaptchaToken, string CaptchaAnswer);
