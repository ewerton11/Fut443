namespace Domain.Repository;

public interface IUserRepository
{
    Task CreateAsync(UserEntity user);
}
