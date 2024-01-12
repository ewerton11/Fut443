using Infrastructure.DTOs;

namespace Infrastructure.Repository.Abstractions;

public interface IUserRepository
{
    Task CreateAsync(BaseUserEntityDto userDTOs);
}
