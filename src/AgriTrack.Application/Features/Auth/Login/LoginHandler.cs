using AgriTrack.Application.Common;
using AgriTrack.Application.Features.Auth.Register;
using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Auth.Login;

public sealed class LoginHandler
{
    private readonly IStoredProcRepository _repository;
    private readonly JwtTokenGenerator _tokenGenerator;
    private readonly CaptchaService _captcha;

    public LoginHandler(IStoredProcRepository repository, JwtTokenGenerator tokenGenerator, CaptchaService captcha)
    {
        _repository = repository;
        _tokenGenerator = tokenGenerator;
        _captcha = captcha;
    }

    public async Task<AuthResponse> HandleAsync(LoginRequest request)
    {
        if (!_captcha.Validate(request.CaptchaToken, request.CaptchaAnswer))
        {
            throw new ArgumentException("Incorrect answer to the security question. Please try again.");
        }

        var user = await _repository.QuerySingleOrDefaultAsync<User>(
            StoredProcedures.GetUserByEmailOrPhone, new { request.EmailOrPhone });

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Invalid email/phone or password.");
        }

        var token = _tokenGenerator.GenerateToken(user);
        return new AuthResponse(token, user.Id, user.Name, user.EmailOrPhone, user.PreferredLanguage, user.HasCompletedCropSelection);
    }
}
