using Domain.Repository;
using Domain.Services.Interfaces;
using Domain.ValueObject;

namespace Domain.Services;

public class BaseUserEntityService : IBaseUserEntityService
{
    private readonly IUserRepository _userRepository;
    private readonly IAdminRepository _adminRepository;

    public BaseUserEntityService(IUserRepository userRepository, IAdminRepository adminRepository)
    {
        _userRepository = userRepository;
        _adminRepository = adminRepository;
    }

    public async Task<bool> IsEmailUniqueAsync(Email email)
    {
        bool userExists = await _userRepository.EmailExistsAsync(email);
        bool adminExists = await _adminRepository.EmailExistsAsync(email);

        return !(userExists || adminExists);
    }
}