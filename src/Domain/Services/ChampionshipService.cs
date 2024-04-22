using Domain.Repository;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class ChampionshipService : IChampionshipService
{
    private readonly IBaseRepository<PlayerEntity> _playerRepository;
    private readonly IClubChampionshipRepository _clubChampionshipRepository;

    public ChampionshipService(
        IBaseRepository<PlayerEntity> playerRepository,
        IClubChampionshipRepository clubChampionshipRepository)
    {
        _playerRepository = playerRepository;
        _clubChampionshipRepository = clubChampionshipRepository;
    }

    public async Task<bool> IsPlayerInChampionship(Guid playerId, Guid championshipId)
    {
        var player = await _playerRepository.GetByIdAsync(playerId);
        if (player == null)
            return false;

        var clubId = player.ClubId;
        if (clubId == null)
            return false;

        var clubChampionship = await _clubChampionshipRepository
            .GetByClubIdAndChampionshipIdAsync(clubId, championshipId);

        return clubChampionship != null;
    }
}

