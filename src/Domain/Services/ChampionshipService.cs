using Domain.Repository;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class ChampionshipService : IChampionshipService
{
    private readonly IBaseRepository<PlayerEntity> _playerRepository;
    private readonly IBaseRepository<ClubChampionship> _clubChampionshipRepository;

    public ChampionshipService(
        IBaseRepository<PlayerEntity> playerRepository,
        IBaseRepository<ClubChampionship> clubChampionshipRepository)
    {
        _playerRepository = playerRepository;
        _clubChampionshipRepository = clubChampionshipRepository;
    }

    public async Task<bool> IsPlayerInChampionship(Guid playerId, Guid championshipId)
    {
        var player = await _playerRepository.GetByIdAsync(playerId);
        if (player == null)
            return false;

        var club = player.ClubEntity;
        if (club == null)
            return false;

        var allClubChampionships = await _clubChampionshipRepository.GetAllAsync();
        var clubChampionship = allClubChampionships.FirstOrDefault(cc => cc.ClubId == club.Id
                                                                    && cc.ChampionshipId == championshipId);


        return clubChampionship != null;
    }
}

