using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entities;

public class UserRootEntity : BaseUserEntity
{
    public static UserRootEntity Create()
    {
        var userRoot = new UserRootEntity
        {
            UserName = UserName.Create("ewerton"),
            Email = Email.Create("ewertonreis@email.com"),
            Password = "minhapicamegazorde123",
            Role = UserRole.UserRoot
        };

        return userRoot;
    }
}
