namespace Morali.Application.Auth.Commands.Login;

public record LoginCommandResponse(
    string AccessToken,
    string RefreshToken,
    UserLoginResponse User
);

public record UserLoginResponse(string Name, string Email);