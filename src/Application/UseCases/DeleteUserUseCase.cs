using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases;

public class DeleteUserUseCase
{
    private readonly IBaseRepository<UserEntity> _baseRepository;

    public DeleteUserUseCase(IBaseRepository<UserEntity> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task DeleteUser(Guid userId)
    {
        var existingUser = await _baseRepository.GetByIdAsync(userId) ?? throw new Exception("User with ID not found.");

        await _baseRepository.DeleteAsync(existingUser.Id);
    }
}
