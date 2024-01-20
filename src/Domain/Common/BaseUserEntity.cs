using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Common;

public abstract class BaseUserEntity : BaseEntity
{
    public UserName UserName { get; protected set; } = UserName.Create(string.Empty);

    public Email Email { get; protected set; } = Email.Create(string.Empty);

    public string Password { get; protected set; } = string.Empty;

    public UserRole Role { get; protected set; } = UserRole.Common;

    protected BaseUserEntity() { }
}

