using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases.Player.ReadPlayer;

public class PlayersChampionshipUseCase : IPlayersChampionshipUseCase
{
    private readonly IPlayerRepository _playerRepository;

    public PlayersChampionshipUseCase(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<List<object>> GetPlayersByChampionshipAsync(Guid championshipId)
    {
        return await _playerRepository.GetAllPlayersByChampionshipAsync(championshipId);
    }
}
