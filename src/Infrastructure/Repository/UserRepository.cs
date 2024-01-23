using Domain.Entities;
using Domain.Interface.Repository;
using Domain.ValueObject;
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

    public async Task CreateAsync(UserEntityDto userDto)
    {
        var user = UserEntity.Create(userDto.UserName, userDto.Email, userDto.Password);

        await _baseRepository.CreateAsync(user);
    }
}

