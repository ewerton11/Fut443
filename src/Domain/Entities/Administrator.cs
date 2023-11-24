namespace Domain.Entities;

public class Administrator : BaseUserEntity
{
    public Administrator(Guid id, string name, string email, string password, string userName, string role)
        : base(id, name, email, password, userName, role)
    {
    }
}
