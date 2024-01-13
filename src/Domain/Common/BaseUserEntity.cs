using Domain.ValueObject;

namespace Domain.Common;

public abstract class BaseUserEntity : BaseEntity
{
    public UserName UserName { get; private set; }

    public Email Email { get; private set; }

    public string Password { get; private set; }

    public string Role { get; private set; }

    public BaseUserEntity(UserName userName, Email email, string password, string role = "role")
    {
        UserName = userName;
        Email = email;
        Password = password;
        Role = role;
    }
}

