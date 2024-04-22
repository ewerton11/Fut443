using Domain.ValueObject;
using Domain.ValueObjects;

namespace Domain.Entities.Base;

public abstract class BaseUserEntity : BaseEntity
{
    public FirstName FirstName { get; protected set; } = null!;
    public LastName LastName { get; protected set; } = null!;
    public Email Email { get; protected set; } = null!;
    public string PasswordHash { get; protected set; } = null!;

    protected BaseUserEntity() { }
}