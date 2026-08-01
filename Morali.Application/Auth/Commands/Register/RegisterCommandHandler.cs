using Morali.Application.Common.Interfaces;
using Morali.Application.Common.Results;
using Morali.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Morali.Application.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<RegisterCommandResponse>>
{
    private readonly IAppDbContext _db;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(IAppDbContext db, IPasswordHasher passwordHasher)
    {
        _db = db;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<Result<RegisterCommandResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userFound = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (userFound != null) return new Result<RegisterCommandResponse>().Conflict("O usuário já existe");

        var passwordHashed = _passwordHasher.Hash(request.Password);
        var newUser = User.Create(request.Name, request.Email, passwordHashed);
        
        _db.Users.Add(newUser);
        await _db.SaveChangesAsync(cancellationToken);
        
        return new Result<RegisterCommandResponse>().Created(new RegisterCommandResponse("Usuário criado com sucesso"));
    }
}