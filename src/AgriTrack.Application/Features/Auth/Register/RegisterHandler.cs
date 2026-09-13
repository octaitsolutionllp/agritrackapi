using AgriTrack.Application.Common;
using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Auth.Register;

public sealed class RegisterHandler
{
    private readonly IStoredProcRepository _repository;
    private readonly JwtTokenGenerator _tokenGenerator;
    private readonly CaptchaService _captcha;

    public RegisterHandler(IStoredProcRepository repository, JwtTokenGenerator tokenGenerator, CaptchaService captcha)
    {
        _repository = repository;
        _tokenGenerator = tokenGenerator;
        _captcha = captcha;
    }

    public async Task<AuthResponse> HandleAsync(RegisterRequest request)
    {
        if (!_captcha.Validate(request.CaptchaToken, request.CaptchaAnswer))
        {
            throw new ArgumentException("Incorrect answer to the security question. Please try again.");
        }

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

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = name,
            EmailOrPhone = emailOrPhone,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            PreferredLanguage = request.PreferredLanguage
        };

        var created = await _repository.QuerySingleOrDefaultAsync<User>(StoredProcedures.CreateUser, new
        {
            user.Id,
            user.Name,
            user.EmailOrPhone,
            user.PasswordHash,
            user.PreferredLanguage
        }) ?? user;

        var token = _tokenGenerator.GenerateToken(created);
        return new AuthResponse(token, created.Id, created.Name, created.EmailOrPhone, created.PreferredLanguage, created.HasCompletedCropSelection);
    }
}
