using Domain.Entities;
using Domain.Repository;
using Domain.ValueObject;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class AdminRepository : IAdminRepository
{
    private readonly DataContext _dbContext;

    public AdminRepository(DataContext context)
    {
        _dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<bool> NameExistsAsync(string name)
    {
        return await _dbContext.Admin.AnyAsync(u => u.Name == name);
    }

    public async Task<bool> EmailExistsAsync(Email email)
    {
        return await _dbContext.Admin.AnyAsync(u => u.Email.Equals(email));
    }

    public async Task<AdminEntity?> GetUserByEmailAsync(Email email)
    {
        var admin = await _dbContext.Admin.FirstOrDefaultAsync(u => u.Email.Equals(email));

        return admin;
    }
}