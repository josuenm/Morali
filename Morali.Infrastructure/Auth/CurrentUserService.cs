using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Morali.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Morali.Infrastructure.Auth;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId
    {
        get
        {
            var sub = _httpContextAccessor
                .HttpContext?
                .User
                .Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return sub is null ? null : Guid.Parse(sub);
        }
    }

    public string? Email =>
        _httpContextAccessor
            .HttpContext?
            .User
            .Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
}