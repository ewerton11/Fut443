using Domain.Entities;

namespace Application.UseCases.Interfaces;

public interface IPlayersChampionshipUseCase
{
    Task<List<object>> GetPlayersByChampionshipAsync(Guid championshipId);
}
