using AgriTrack.Application.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AgriTrack.Application.Features.Auth.Captcha;

public sealed record CaptchaResponse(string Token, string Question);

public static class GetCaptchaEndpoint
{
    public static void MapGetCaptchaEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/auth/captcha", (CaptchaService captcha) =>
        {
            var (token, question) = captcha.GenerateChallenge();
            return Results.Ok(new CaptchaResponse(token, question));
        })
        .WithName("GetCaptcha")
        .AllowAnonymous();
    }
}
