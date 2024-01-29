/*
using Domain.Interface.Repository;

namespace Domain.Services;

public class AdminService
{
    private readonly IBaseRepository<PlayerEntity> _baseRepository;

    public AdminService(IBaseRepository<PlayerEntity> baseRepository) 
    {
        _baseRepository = baseRepository;
    }

    public async Task AddAvailablePlayerAsync(PlayerEntity player)
    {


        await _baseRepository.CreateAsync(player);
    }
}
*/
