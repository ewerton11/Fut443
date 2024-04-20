using Domain.Aggregates;
using Domain.ValueObject;

namespace Domain.Repository;

public interface IUserRepository
{
    Task CreateUserAsync(UserEntity user);
    Task<UserEntity?> GetUserByIdAsync(Guid userId);
    Task<UserEntity?> GetUserByEmailAsync(Email email);
    //Task<bool> EmailExistsAsync(Email email);
    //Task<bool> UserNameExistsAsync(UserName userName);
    //Task<object?> GetUserByIdAndTeam(Guid id);
}
