using Application.Authentication;
using Application.DTOs.User.CreateUser;
using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repository;
using Domain.Services.Interfaces;
using Domain.ValueObject;
using Domain.ValueObjects;

namespace Application.UseCases;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IBaseUserEntityService _baseUserEntityService;
    private readonly IUserService _userService;

    public CreateUserUseCase(IUserRepository userRepository, IPasswordHashService passwordHashService,
        IBaseUserEntityService baseUserEntityService, IUserService userService)
    {
        _userRepository = userRepository;
        _passwordHashService = passwordHashService;
        _baseUserEntityService = baseUserEntityService;
        _userService = userService;
    }

    public async Task CreateUserAsync(CreateUserDTO userDto)
    {
        var firstNameResult = FirstName.Create(userDto.FirstName);
        var lastNameResult = LastName.Create(userDto.LastName);
        var birthDateResult = BirthDate.Create(userDto.Birthday);
        var userNameResult = UserName.Create(userDto.UserName);
        var emailResult = Email.Create(userDto.Email);
        var passwordResult = Password.Create(userDto.Password);

        if (!await _userService.IsUserNameUniqueAsync(userNameResult))
        {
            throw new InvalidOperationException("This username already exists.");
        }

        if (!await _baseUserEntityService.IsEmailUniqueAsync(emailResult))
        {
            throw new InvalidOperationException("This email already exists.");
        }

        var passwordHash = _passwordHashService.HashPassword(passwordResult.Value);

        var user = UserEntity.Create(firstNameResult, lastNameResult, birthDateResult, userNameResult, 
            emailResult, passwordHash);

        if(!user.IsAdult()) 
            throw new InvalidOperationException("You must be at least 18 years old to create an account.");

        await _userRepository.CreateUserAsync(user);
    }
}