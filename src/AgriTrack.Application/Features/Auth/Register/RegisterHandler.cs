using AgriTrack.Application.Common;
using AgriTrack.Domain.Entities;
using AgriTrack.Infrastructure;

namespace AgriTrack.Application.Features.Auth.Register;

public sealed class RegisterHandler
{
    private readonly IStoredProcRepository _repository;
    private readonly JwtTokenGenerator _tokenGenerator;

    public RegisterHandler(IStoredProcRepository repository, JwtTokenGenerator tokenGenerator)
    {
        _repository = repository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AuthResponse> HandleAsync(RegisterRequest request)
    {
        var existing = await _repository.QuerySingleOrDefaultAsync<User>(
            StoredProcedures.GetUserByEmailOrPhone, new { request.EmailOrPhone });
        if (existing is not null)
        {
            throw new InvalidOperationException("An account with this email or phone already exists.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            EmailOrPhone = request.EmailOrPhone,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
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
