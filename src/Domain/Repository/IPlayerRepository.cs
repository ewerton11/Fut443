using Domain.Enums;

namespace Domain.Repository;

public interface IPlayerRepository
{
    Task CreatePlayerAsync(PlayerEntity player);
    Task<PlayerEntity> GetPlayerByIdAsync(Guid playerId);
    Task<bool> IsPlayerInClubAsync(string name, string club);
}
