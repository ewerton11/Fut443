using Domain.Entities.Base;
using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entities;

public class AdminEntity : BaseUserEntity
{
    //adicionar last name

    private AdminEntity() { }

    public static AdminEntity Create(string name, string email, string passwordHash, UserRole requestingUser)
    {
        if (requestingUser != UserRole.root)
        {
            throw new UnauthorizedAccessException("Apenas o usuário 'root' pode criar um administrador.");
        }

        var emailResult = Email.Create(email);
       // var passwordResult = Password.Create(password);

        var admin = new AdminEntity
        {
            Name = name,
            Email = emailResult,
            PasswordHash = passwordHash,
            Role = UserRole.root
        };

        return admin;
    }
}