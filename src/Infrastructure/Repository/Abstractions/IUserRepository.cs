using Domain.Entities;

namespace Infrastructure.Repository.Abstractions;

public interface IUserRepository
{
    Task CreateAsync(User user);
}
