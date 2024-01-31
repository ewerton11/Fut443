using Domain.ValueObject;

namespace Domain.Repository;

public interface IUserRepository
{
    Task<bool> EmailExistsAsync(string email);
}
