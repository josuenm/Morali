namespace Morali.Application.Auth.Commands.RefreshToken;

public record RefreshTokenCommandResponse(
    string AccessToken,
    string RefreshToken
);