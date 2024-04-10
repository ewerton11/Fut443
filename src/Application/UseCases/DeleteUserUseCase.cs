/*
using Application.Authentication;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases;

public class DeleteUserUseCase
{
    private readonly IPasswordHashService _passwordHashService;
    private readonly IBaseRepository<UserEntity> _baseRepository;

    public DeleteUserUseCase(IPasswordHashService passwordHashService, IBaseRepository<UserEntity> baseRepository)
    {
        _passwordHashService = passwordHashService;
        _baseRepository = baseRepository;
    }

    public async Task DeleteUser(Guid userId, string password)
    {
        if(string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be null or empty");

        var existingUser = await _baseRepository.GetByIdAsync(userId) ?? throw new Exception("User with ID not found.");

        var validPassword = _passwordHashService.VerifyPassword(password, existingUser.PasswordHash);

        if(!validPassword) throw new Exception("Incorrect password");

        await _baseRepository.DeleteAsync(existingUser.Id);
    }
}
*/