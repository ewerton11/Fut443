using Application.Authentication;
using Application.DTOs.CreateDTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Repository;
using Domain.ValueObject;

namespace Application.UseCases;

public class CreateAdminUseCase
{
    private readonly IAdminRepository _adminRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IBaseRepository<AdminEntity> _baseRepository;

    public CreateAdminUseCase(IAdminRepository adminRepository, IPasswordHashService passwordHashService,
        IBaseRepository<AdminEntity> baseRepository)
    {
        _adminRepository = adminRepository;
        _passwordHashService = passwordHashService;
        _baseRepository = baseRepository;
    }

    public async Task CreateAdminAsync(AdminEntityDto adminDto)
    {
        if (await _adminRepository.NameExistsAsync(adminDto.Name))
        {
            throw new InvalidOperationException("This name already exists.");
        }

        if (await _adminRepository.EmailExistsAsync(Email.Create(adminDto.Email)))
        {
            throw new InvalidOperationException("This email already exists.");
        }

        var passwordHash = _passwordHashService.HashPassword(adminDto.Password);

        var admin = AdminEntity.Create(adminDto.Name, adminDto.Email, passwordHash, null);

        await _baseRepository.CreateAsync(admin);
    }
}
