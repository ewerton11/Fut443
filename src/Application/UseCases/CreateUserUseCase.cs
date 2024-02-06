using Application.DTOs.CreateDTOs;
using Application.Service;
using Domain.Entities;
using Domain.Repository;
using Domain.ValueObject;

namespace Application.UseCases;

public class CreateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IBaseRepository<UserEntity> _baseRepository;

    public CreateUserUseCase(IUserRepository userRepository, IPasswordHashService passwordHashService,
        IBaseRepository<UserEntity> baseRepository)
    {
        _userRepository = userRepository;
        _passwordHashService = passwordHashService;
        _baseRepository = baseRepository;
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
}
