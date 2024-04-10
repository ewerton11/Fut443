using Domain.ValueObject;

namespace Domain.Repository;

public interface IAdminRepository
{
    Task AddAdminAsync(AdminEntity admin);
    Task<AdminEntity> GetAdminAsync(Guid adminId);
    Task<AdminEntity?> GetAdminByEmailAsync(Email email);
}
