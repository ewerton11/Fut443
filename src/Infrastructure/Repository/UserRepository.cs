using Domain.Entities;
using Domain.Repository;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IBaseRepository<UserEntity> _baseRepository;

    public UserRepository(IBaseRepository<UserEntity> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task CreateAsync(UserEntity user)
    {
        await _baseRepository.CreateAsync(user);
    }
}