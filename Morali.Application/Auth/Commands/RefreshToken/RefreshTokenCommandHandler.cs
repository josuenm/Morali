using Morali.Application.Common.Interfaces;
using Morali.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RefreshTokenEntity = Morali.Domain.Entities.RefreshToken;

namespace Morali.Application.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Result<RefreshTokenCommandResponse>>
{
    private readonly IAppDbContext _db;
    private readonly IJwtTokenService _jwtTokenService;

    public RefreshTokenCommandHandler(
        IAppDbContext db,
        IJwtTokenService jwtTokenService
    )
    {
        _db = db;
        _jwtTokenService = jwtTokenService;
    }
    
    public async Task<Result<RefreshTokenCommandResponse>> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken
    )
    {
        var refreshTokenFound = await _db.RefreshTokens
            .FirstOrDefaultAsync(q => q.Token == request.RefreshToken, cancellationToken);

        if (refreshTokenFound is null)
            return new Result<RefreshTokenCommandResponse>()
                .BadRequest("Refresh token inválido ou não existe");
        
        if (!refreshTokenFound.IsActive)
            return new Result<RefreshTokenCommandResponse>()
                .BadRequest("O refresh token já foi revogado");
        
        var user = await _db.Users.FirstOrDefaultAsync(q => q.Id == refreshTokenFound.UserId, cancellationToken);

        if (user is null)
            return new Result<RefreshTokenCommandResponse>()
                .BadRequest("Refresh token inválido");

        var accessToken = _jwtTokenService.GenerateAccessToken(user);
        var refreshToken = _jwtTokenService.GenerateRefreshToken(user.Id);

        var newRefreshToken = RefreshTokenEntity.Create(
            refreshToken, 
            user.Id, 
            _jwtTokenService.GetRefreshTokenExpiration()
        );

        refreshTokenFound.Revoke();
        _db.RefreshTokens.Add(newRefreshToken);
        await _db.SaveChangesAsync(cancellationToken);
        
        return new Result<RefreshTokenCommandResponse>().Ok(new (accessToken, refreshToken));
    }
}