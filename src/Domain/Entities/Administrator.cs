using Domain.ValueObject;

namespace Domain.Entities;

public class Administrator : BaseUserEntity
{
    public Administrator(UserName userName, Email email, string password, string role)
        : base(userName, email, password, role)
    {
    }
}
