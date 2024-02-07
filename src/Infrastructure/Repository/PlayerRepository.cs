using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PlayerRepository : IPlayerRepository
{
    private readonly DataContext _dataContext;

    public PlayerRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> IsPlayerInClubAsync(string name, string club)
    {
        var existingPlayer = await _dataContext.Player
            .Where(p => p.Name == name && p.Club == club)
                .FirstOrDefaultAsync();

        return existingPlayer != null;
    }
}
