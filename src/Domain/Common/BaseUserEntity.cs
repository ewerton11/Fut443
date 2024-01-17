using Domain.ValueObject;

namespace Domain.Common;

public abstract class BaseUserEntity : BaseEntity
{
    public UserName UserName { get; protected set; } = UserName.Create(string.Empty);

    public Email Email { get; protected set; } = Email.Create(string.Empty);

    public string Password { get; protected set; } = string.Empty;

    public string Role { get; protected set; } = "user";

    protected BaseUserEntity() { }
}

