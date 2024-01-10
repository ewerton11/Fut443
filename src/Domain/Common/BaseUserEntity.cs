using Domain.ValueObject;

namespace Domain.Common;

public abstract class BaseUserEntity : BaseEntity
{
    public Name Name { get; private set; }

    public string Email { get; private set; }

    public string Password { get; private set; }

    public string UserName { get; private set; }

    public string Role { get; private set; }

    public BaseUserEntity(Name name, string email, string password, string userName,
        string role)
    {
        Name = name;
        Email = email;
        Password = password;
        UserName = userName;
        Role = role;
    }
}

