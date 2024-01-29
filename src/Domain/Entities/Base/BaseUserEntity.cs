using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entities.Base;

public abstract class BaseUserEntity : BaseEntity
{
    public Email Email { get; protected set; }

    public Password Password { get; protected set; }

    public UserRole Role { get; protected set; } = UserRole.common;

    protected BaseUserEntity() { }
}