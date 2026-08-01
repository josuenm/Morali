using Morali.Domain.Entities;

namespace Morali.Application.Common.Interfaces;

public interface IJwtTokenService
{
    public DateTime GetRefreshTokenExpiration();
    public string GenerateAccessToken(User user);
    public string GenerateRefreshToken(Guid userId);
}