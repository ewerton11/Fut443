using Domain.Entities.Base;
using Domain.Enums;
using Domain.ValueObject;
using Domain.ValueObjects;

namespace Domain.Entities;

public class AdminEntity : BaseUserEntity
{
    public AdminLevel Level { get; private set; }

    private AdminEntity() { }

    public static AdminEntity Create(FirstName firstName, LastName lastName, Email email,
        string passwordHash, AdminLevel level, AdminLevel currentAdminLevel)
    {
        ValidateAdminCreation(level, currentAdminLevel);

        var admin = new AdminEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
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