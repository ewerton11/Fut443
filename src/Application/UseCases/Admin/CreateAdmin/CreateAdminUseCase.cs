using Application.Authentication;
using Application.DTOs.Admin;
using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repository;
using Domain.Services.Interfaces;
using Domain.ValueObject;
using Domain.ValueObjects;

namespace Application.UseCases.Admin;

public class CreateAdminUseCase : ICreateAdminUseCase
{
    private readonly IAdminRepository _adminRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IBaseUserEntityService _baseUserEntityService;

    public CreateAdminUseCase(IAdminRepository adminRepository, IPasswordHashService passwordHashService, 
        IBaseUserEntityService baseUserEntityService)
    {
        _adminRepository = adminRepository;
        _passwordHashService = passwordHashService;
        _baseUserEntityService = baseUserEntityService;
    }

    public async Task CreateAdminAsync(CreateAdminDTO adminDto, Guid adminId)
    {
        var firstNameResult = FirstName.Create(adminDto.FirstName);
        var lastNameResult = LastName.Create(adminDto.LastName);
        var emailResult = Email.Create(adminDto.Email);
        var passwordResult = Password.Create(adminDto.Password);

        if (await _baseUserEntityService.IsEmailUniqueAsync(emailResult))
        {
            throw new InvalidOperationException("This email already exists.");
        }

        var creatorAdmin = await _adminRepository.GetAdminAsync(adminId);

        var passwordHash = _passwordHashService.HashPassword(passwordResult.Value);

        var admin = AdminEntity.Create(firstNameResult, lastNameResult, emailResult,
            passwordHash, adminDto.Level, creatorAdmin.Level);

        await _adminRepository.AddAdminAsync(admin);
    }
}
