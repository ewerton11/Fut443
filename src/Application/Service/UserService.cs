using Application.DTOs;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Repository;

namespace Application.Service;

public class UserService
{
    private readonly IBaseRepository<UserEntity> _baseRepository;
    private readonly IUserRepository _userRepository;

    public UserService(IBaseRepository<UserEntity> baseRepository, IUserRepository userRepository)
    {
        _baseRepository = baseRepository;
        _userRepository = userRepository;
    }

    public async Task CreateUserAsync(UserEntityDto userDto)
    {
        if (await _userRepository.EmailExistsAsync(userDto.Email))
        {
            throw new InvalidOperationException("Email already exists.");
        }

        var user = UserEntity.Create(userDto.UserName, userDto.Email, userDto.Password);

        await _baseRepository.CreateAsync(user);
    }
}
