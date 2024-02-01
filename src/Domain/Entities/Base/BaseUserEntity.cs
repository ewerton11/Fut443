using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entities.Base;

public abstract class BaseUserEntity : BaseEntity
{
    public string Name { get; protected set; }

    public Email Email { get; protected set; }

    public string PasswordHash { get; protected set; }

    public UserRole Role { get; protected set; } = UserRole.common;

    protected BaseUserEntity() { }
}