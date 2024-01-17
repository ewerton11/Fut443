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
        var userNameResult = UserName.Create(userDto.UserName);
        var emailResult = Email.Create(userDto.Email);

        var user = UserEntity.Create(userNameResult, emailResult, userDto.Password);

        await _baseRepository.CreateAsync(user);
    }
}

