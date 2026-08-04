using Morali.Application.Common.Interfaces;
using Morali.Application.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Morali.Application.Auth.Queries.Me;

public class MeQueryHandler : IRequestHandler<MeQuery, Result<MeQueryResponse>>
{
    private readonly IAppDbContext _db;
    private readonly ICurrentUserService _currentUserService;
    
    public MeQueryHandler(IAppDbContext db, ICurrentUserService currentUserService)
    {
        _db = db;
        _currentUserService = currentUserService;
    }
    
    public async Task<Result<MeQueryResponse>> Handle(MeQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;

        if (userId is null) return new Result<MeQueryResponse>().Unauthorized("Acesso negado");
        
        var user = await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId.Value, cancellationToken);

        if (user is null) return new Result<MeQueryResponse>().NotFound("Usuário não encontrado");
        
        return new Result<MeQueryResponse>().Ok(new(user.Name, user.Email));
    }
}