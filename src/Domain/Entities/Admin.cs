using Domain.Entities.Base;
using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entities;

public class AdminEntity : BaseUserEntity
{
    private AdminEntity() { }

    public static AdminEntity Create(string name, string email, string passwordHash, UserRole role)
    {
        var emailResult = Email.Create(email);
       // var passwordResult = Password.Create(password);

        var admin = new AdminEntity
        {
            Name = name,
            Email = emailResult,
            PasswordHash = passwordHash,
            Role = role
        };

        return admin;
    }
}