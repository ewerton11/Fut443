using Domain.Enums;

namespace Domain.Repository;

public interface IPlayerRepository
{
    Task CreatePlayerAsync(PlayerEntity player);
    Task<bool> IsPlayerInClubAsync(string name, string club);
}
