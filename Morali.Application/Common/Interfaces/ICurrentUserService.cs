namespace Morali.Application.Common.Interfaces;

public interface ICurrentUserService
{
    public Guid? UserId { get; }
    public string? Email { get; }
}