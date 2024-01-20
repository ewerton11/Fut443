using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entities;

public class AdministratorEntity : BaseUserEntity
{
    public static AdministratorEntity Create(UserName userName, Email email, string password)
    {
        var administrator = new AdministratorEntity
        {
            UserName = userName,
            Email = email,
            Password = password,
            Role = UserRole.Administrator
        };

        return administrator;
    }
}