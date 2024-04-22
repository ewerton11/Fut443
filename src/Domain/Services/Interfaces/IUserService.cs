using Domain.ValueObject;

namespace Domain.Services.Interfaces;

public interface IUserService
{
    Task<bool> IsUserNameUniqueAsync(UserName userName);
}
