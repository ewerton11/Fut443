using Domain.Entities;
using Domain.Repository;
using Domain.ValueObject;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class AdminRepository : IAdminRepository
{
    private readonly IBaseRepository<AdminEntity> _baseRepository;
    private readonly DataContext _dbContext;

    public AdminRepository(IBaseRepository<AdminEntity> baseRepository, DataContext dbContext)
    {
        _baseRepository = baseRepository;
        _dbContext = dbContext;
    }

    public async Task AddAdminAsync(AdminEntity admin)
    {
        await _baseRepository.CreateAsync(admin);
    }

    public async Task<AdminEntity> GetAdminAsync(Guid adminId)
    {
        return await _baseRepository.GetByIdAsync(adminId);
    }

    public async Task<AdminEntity?> GetAdminByEmailAsync(Email email)
    {
        var admin = await _dbContext.Admin.FirstOrDefaultAsync(u => u.Email.Equals(email));

        return admin;
    }

    /*
    public async Task<bool> EmailExistsAsync(Email email)
    {
        return await _dbContext.Admin.AnyAsync(u => u.Email.Equals(email));
    }
    */
}