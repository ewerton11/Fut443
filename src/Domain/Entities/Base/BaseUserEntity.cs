using Domain.ValueObject;

namespace Domain.Entities.Base;

public abstract class BaseUserEntity : BaseEntity
{
    public string FirstName { get; protected set; } = null!;

    public Email Email { get; protected set; } = null!;

    public string PasswordHash { get; protected set; } = null!;

    protected BaseUserEntity() { }
}