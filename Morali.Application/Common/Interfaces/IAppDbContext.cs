using Morali.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PropertyEntity = Morali.Domain.Entities.Property;

namespace Morali.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    DbSet<RefreshToken> RefreshTokens { get; }
    DbSet<PropertyEntity> Properties { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}