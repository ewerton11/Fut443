using Application.DTOs.Player.ReadPlayer;

namespace Application.UseCases.Interfaces;

public interface IPlayersChampionshipUseCase
{
    Task<List<ReadPlayerDTO>> GetPlayersByChampionshipAsync(Guid championshipId);
}
