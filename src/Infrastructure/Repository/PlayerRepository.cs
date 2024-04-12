using Domain.Entities;
using Domain.Enums;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly IBaseRepository<PlayerEntity> _baseRepository;
    private readonly DataContext _dataContext;

    public PlayerRepository(IBaseRepository<PlayerEntity> baseRepository, DataContext dataContext)
    {
        _baseRepository = baseRepository;
        _dataContext = dataContext;
    }

    public async Task CreatePlayerAsync(PlayerEntity player)
    {
        await _baseRepository.CreateAsync(player);
    }

    public async Task<bool> IsPlayerInClubAsync(string name, string club)
    {
        var existingPlayer = await _dataContext.Player
            .Where(p => p.Name == name && p.Club == club)
                .FirstOrDefaultAsync();

        return existingPlayer != null;
    }
}
