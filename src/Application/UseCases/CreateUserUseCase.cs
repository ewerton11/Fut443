using Application.Authentication;
using Application.DTOs.CreateDTOs;
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
        var userNameResult = UserName.Create(userDto.UserName);
        var emailResult = Email.Create(userDto.Email);
        var passwordResult = Password.Create(userDto.Password);

        if (await _userRepository.UserNameExistsAsync(userNameResult))
        {
            throw new InvalidOperationException("This username already exists.");
        }

        if (await _userRepository.EmailExistsAsync(emailResult))
        {
            throw new InvalidOperationException("This email already exists.");
        }

        var passwordHash = _passwordHashService.HashPassword(passwordResult.Value);

        var user = UserEntity.Create(userNameResult, emailResult, passwordHash);

        await _baseRepository.CreateAsync(user);
    }
}
