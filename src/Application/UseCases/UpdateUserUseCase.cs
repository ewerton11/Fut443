using Application.Authentication;
using Application.DTOs.UpdateDTOs;
using Domain.Entities;
using Domain.Repository;
using Domain.ValueObject;

namespace Application.UseCases;

public class UpdateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IBaseRepository<UserEntity> _baseRepository;

    public UpdateUserUseCase(IUserRepository userRepository, IPasswordHashService passwordHashService,
        IBaseRepository<UserEntity> baseRepository)
    {
        _baseRepository = baseRepository;
        _userRepository = userRepository;
        _passwordHashService = passwordHashService;
    }

    public async Task UpdateUser(UpdateUserDto userDto, Guid userId)
    {
        var existingUser = await _baseRepository.GetByIdAsync(userId) ?? throw new Exception("User with ID not found.");

        if (userDto.Name != null)
        {
            existingUser.UpdateName(userDto.Name);
        }

        if (userDto.UserName != null)
        {
            var userNameResult = UserName.Create(userDto.UserName);

            if (await _userRepository.UserNameExistsAsync(userNameResult))
            {
                throw new InvalidOperationException("This username already exists.");
            }

            existingUser.UpdateUserName(userNameResult);
        }

        if (userDto.Email != null)
        {
            var emailResult = Email.Create(userDto.Email);

            if (await _userRepository.EmailExistsAsync(emailResult))
            {
                throw new InvalidOperationException("This email already exists.");
            }

            existingUser.UpdateEmail(emailResult);
        }

        if (userDto.Password != null)
        {
            var passwordResult = Password.Create(userDto.Password);

            var passwordHash = _passwordHashService.HashPassword(passwordResult.Value);

            existingUser.UpdatePassword(passwordHash);
        }

        await _baseRepository.UpdateAsync(existingUser);
    }
}
