using Domain.Entities;
using Domain.Interface.Repository;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IBaseRepository<User> _baseRepository;

    public UserRepository(IBaseRepository<User> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task CreateAsync(User user)
    {
        await _baseRepository.CreateAsync(user);
    }
}

