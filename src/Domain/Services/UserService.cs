using Domain.Repository;
using Domain.Services.Interfaces;
using Domain.ValueObject;

namespace Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> IsUserNameUniqueAsync(UserName userName)
    {
        return !(await _userRepository.UserNameExistsAsync(userName));
    }
}
