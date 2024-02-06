using Domain.ValueObject;

namespace Domain.Repository;

public interface IAdminRepository
{
    Task<bool> NameExistsAsync(string Name);
    Task<bool> EmailExistsAsync(Email email);
    Task<AdminEntity?> GetUserByEmailAsync(Email email);
}
