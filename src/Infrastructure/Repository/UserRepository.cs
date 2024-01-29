using Domain.Entities;
using Domain.Repository;
using Infrastructure.DTOs;
using Infrastructure.Repository.Abstractions;

namespace Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IBaseRepository<UserEntity> _baseRepository;

    public UserRepository(IBaseRepository<UserEntity> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public Task AuthenticateUserAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(UserEntityDto userDto)
    {
        var user = UserEntity.Create(userDto.UserName, userDto.Email, userDto.Password);

        await _baseRepository.CreateAsync(user);
    }

    public bool VerifyPassword(string user, string password)
    {
        throw new NotImplementedException();
    }
}

