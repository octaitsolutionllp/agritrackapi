using AgriTrack.Application.Common;
using AgriTrack.Application.Features.Auth.Register;
using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Auth.Login;

public sealed class LoginHandler
{
    private readonly IStoredProcRepository _repository;
    private readonly JwtTokenGenerator _tokenGenerator;

    public LoginHandler(IStoredProcRepository repository, JwtTokenGenerator tokenGenerator)
    {
        _repository = repository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AuthResponse> HandleAsync(LoginRequest request)
    {
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
