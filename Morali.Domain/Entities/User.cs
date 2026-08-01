namespace Morali.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    
    public ICollection<Property>? Properties { get; private set; }

    public static User Create(string name, string email, string password)
        => new()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            Password = password,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };
    
    private User() {}
}