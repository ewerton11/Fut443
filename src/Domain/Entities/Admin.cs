using Domain.Entities.Base;
using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entities;

public class AdminEntity : BaseUserEntity
{
    public string Name { get; private set; } = string.Empty;

    private AdminEntity() { }

    public static AdminEntity Create(string name, string email, string password, UserRole role)
    {
        var emailResult = Email.Create(email);
        var passwordResult = Password.Create(password);

        var admin = new AdminEntity
        {
            Name = name,
            Email = emailResult,
            Password = passwordResult,
            Role = role
        };

        return admin;
    }
}