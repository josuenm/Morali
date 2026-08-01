using Morali.Application.Common.Interfaces;
using Morali.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Morali.Application.Auth.Commands.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result<LogoutCommandResponse>>
{
    private readonly IAppDbContext _db;

    public LogoutCommandHandler(IAppDbContext db)
    {
        _db = db;
    }
    
    public async Task<Result<LogoutCommandResponse>> Handle(LogoutCommand request,  CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.RefreshToken)) return new Result<LogoutCommandResponse>()
            .BadRequest("O refresh-token precisa ser fornecido via cookie");
        
        var refreshToken = await _db.RefreshTokens
            .FirstOrDefaultAsync(rf => rf.Token == request.RefreshToken, cancellationToken);

        if (refreshToken is null) 
            return new Result<LogoutCommandResponse>().BadRequest("Token inválido ou não encontrado");

        if (!refreshToken.IsActive)
            return new Result<LogoutCommandResponse>().Conflict("O token já foi revogado");

        refreshToken.Revoke();
        await _db.SaveChangesAsync(cancellationToken);

        return new Result<LogoutCommandResponse>().NoContent();
    }
}