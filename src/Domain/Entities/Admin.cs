using Domain.Entities.Base;
using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entities;

public class AdminEntity : BaseUserEntity
{
    public string LastName { get; private set; } = null!;
    public AdminLevel Level { get; private set; }

    private AdminEntity() { }

    public static AdminEntity Create(string firstName, string lastName, string email, string passwordHash, AdminLevel level,
        AdminLevel currentAdminLevel)
    {
        ValidateAdminCreation(level, currentAdminLevel);

        //email nao pode ser igual

        var emailResult = Email.Create(email);

        var admin = new AdminEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = emailResult,
            PasswordHash = passwordHash,
            Level = level,
        };

        return admin;
    }

    private static void ValidateAdminCreation(AdminLevel newLevel, AdminLevel creatingAdminLevel)
    {
        if (creatingAdminLevel < AdminLevel.HighAdmin)
        {
            throw new ArgumentException("Insufficient privileges to create an admin of this level.");
        }

        if (creatingAdminLevel < newLevel)
        {
            throw new ArgumentException("New admin level cannot be higher or equal to the creating admin's level.");
        }
    }
}