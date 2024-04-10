using Application.Authentication;
using Application.DTOs.Admin;
using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repository;
using Domain.ValueObject;

namespace Application.UseCases.Admin;

public class CreateAdminUseCase : ICreateAdminUseCase
{
    private readonly IAdminRepository _adminRepository;
    private readonly IPasswordHashService _passwordHashService;

    public CreateAdminUseCase(IAdminRepository adminRepository, IPasswordHashService passwordHashService)
    {
        _adminRepository = adminRepository;
        _passwordHashService = passwordHashService;
    }

    public async Task CreateAdminAsync(CreateAdminDTO adminDto, Guid adminId)
    {
        /*
        if (await _adminRepository.NameExistsAsync(adminDto.Name))
        {
            throw new InvalidOperationException("This name already exists.");
        }
        */

        /*
        if (await _adminRepository.EmailExistsAsync(Email.Create(adminDto.Email)))
        {
            throw new InvalidOperationException("This email already exists.");
        }
        */

        var creatorAdmin = await _adminRepository.GetAdminAsync(adminId);

        var passwordHash = _passwordHashService.HashPassword(adminDto.Password);

        var admin = AdminEntity.Create(adminDto.FirstName, adminDto.LastName, adminDto.Email, passwordHash, adminDto.level, creatorAdmin.Level);

        await _adminRepository.AddAdminAsync(admin);
    }
}
