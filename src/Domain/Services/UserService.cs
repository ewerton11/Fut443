/*
using Domain.Interface.Repository;
using Domain.ValueObject;

namespace Domain.Services;

public class UserService
{
    private readonly IBaseRepository<UserEntity> _userRepository;

    public UserService(IBaseRepository<UserEntity> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateUser(string userName, string email, string password)
    {
        var userNameResult = UserName.Create(userName);
        var emailResult = Email.Create(email);

        var newUser = UserEntity.CreateNewUser(userNameResult, emailResult, password);

        await _userRepository.CreateAsync(newUser);
    }
}
*/
