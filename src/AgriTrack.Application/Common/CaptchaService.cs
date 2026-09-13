using Microsoft.Extensions.Caching.Memory;

namespace AgriTrack.Application.Common;

/// <summary>
/// A free, dependency-free CAPTCHA: a simple addition question ("3 + 5 = ?"), answer held
/// server-side in memory keyed by a one-time token. No external service, no API key, no
/// network round-trip beyond this API — just enough friction to stop naive bot submissions.
/// </summary>
public sealed class CaptchaService
{
    private static readonly TimeSpan Ttl = TimeSpan.FromMinutes(5);
    private readonly IMemoryCache _cache;
    private readonly Random _random = new();

    public CaptchaService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public (string Token, string Question) GenerateChallenge()
    {
        var a = _random.Next(1, 10);
        var b = _random.Next(1, 10);
        var token = Guid.NewGuid().ToString("N");
        _cache.Set(CacheKey(token), a + b, Ttl);
        return (token, $"{a} + {b}");
    }

    /// <summary>One-time use: the token is consumed whether the answer is right or wrong, so a
    /// captured token can't be replayed and a failed attempt always needs a fresh challenge.</summary>
    public bool Validate(string? token, string? answer)
    {
        if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(answer))
        {
            return false;
        }

        var key = CacheKey(token);
        if (!_cache.TryGetValue(key, out int expected))
        {
            return false;
        }

        _cache.Remove(key);
        return int.TryParse(answer.Trim(), out var given) && given == expected;
    }

    private static string CacheKey(string token) => $"captcha:{token}";
}
