namespace Morali.Infrastructure.Auth;

public class JwtSettings
{
    public string Secret { get; set; } = String.Empty;
    public string Issuer { get; set; } = String.Empty;
    public string Audience { get; set; } = String.Empty;
    public int ExpiryMinutes { get; set; }
}