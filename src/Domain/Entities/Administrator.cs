using Domain.ValueObject;

namespace Domain.Entities;

public class Administrator : BaseUserEntity
{
    public Administrator(UserName userName, Email email, string password)
        : base(userName, email, password)
    {
    }
}
