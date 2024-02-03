using Application.DTOs;
using Domain.Entities;
using Domain.Repository;
using Domain.ValueObject;
using Infrastructure.Services;

namespace Application.Service;

public class UserService
{
    private readonly IBaseRepository<UserEntity> _baseRepository;
    private readonly IUserRepository _userRepository;
    private readonly PasswordHashService _passwordHashService;

    public UserService(IBaseRepository<UserEntity> baseRepository, IUserRepository userRepository,
        PasswordHashService passwordHashService)
    {
        _baseRepository = baseRepository;
        _userRepository = userRepository;
        _passwordHashService = passwordHashService;
    }

    public async Task CreateUserAsync(UserEntityDto userDto)
    {
        if (await _userRepository.UserNameExistsAsync(UserName.Create(userDto.UserName)))
        {
            throw new InvalidOperationException("This username already exists.");
        }

        if (await _userRepository.EmailExistsAsync(Email.Create(userDto.Email)))
        {
            throw new InvalidOperationException("This email already exists.");
        }

        var passwordHash = _passwordHashService.HashPassword(userDto.Password);

        var user = UserEntity.Create(userDto.Name, userDto.UserName, userDto.Email, passwordHash);

        await _baseRepository.CreateAsync(user);
    }

    public async Task<bool> AuthenticateUser(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(Email.Create(email));

        if (user != null && _passwordHashService.VerifyPassword(password, user.PasswordHash))
        {
            return true;
        }

        return false;
    }
}
