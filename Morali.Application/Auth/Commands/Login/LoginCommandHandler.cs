using Morali.Application.Common.Results;
using Morali.Application.Common.Interfaces;
using RefreshTokenEntity =  Morali.Domain.Entities.RefreshToken;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Morali.Application.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    private readonly IAppDbContext _db;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;

    public LoginCommandHandler(
        IAppDbContext db,
        IPasswordHasher passwordHasher, 
        IJwtTokenService jwtTokenService
    )
    {
        _db = db;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
    }
    
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (user == null) return new Result<LoginCommandResponse>().Unauthorized("Usuário ou senha incorretos");

        if (!_passwordHasher.Verify(request.Password, user.Password))
            return new Result<LoginCommandResponse>()
                .Unauthorized("Usuário ou senha incorretos");

        var accessToken = _jwtTokenService.GenerateAccessToken(user);
        var refreshToken = _jwtTokenService.GenerateRefreshToken(user.Id);

        var refreshTokenEntity = RefreshTokenEntity.Create(
            refreshToken, 
            user.Id, 
            _jwtTokenService.GetRefreshTokenExpiration()
        );
        
        _db.RefreshTokens.Add(refreshTokenEntity);
        await _db.SaveChangesAsync(cancellationToken);

        return new Result<LoginCommandResponse>().Ok(new (
            accessToken,
            refreshToken,
            new UserLoginResponse(user.Name, user.Email)
        ));
    }
}