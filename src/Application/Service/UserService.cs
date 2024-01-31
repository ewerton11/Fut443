using Application.DTOs;
using Domain.Entities;
using Domain.Repository;

namespace Application.Service;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateUser(UserEntityDto userDto)
    {
        var user = UserEntity.Create(userDto.UserName, userDto.Email, userDto.Password);

        await _userRepository.CreateAsync(user);
    }
}
