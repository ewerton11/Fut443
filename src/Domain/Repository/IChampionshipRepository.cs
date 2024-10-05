using Domain.Enums;

namespace Domain.Repository;

public interface IChampionshipRepository
{
    Task AddChampionshipAsync(ChampionshipEntity championship);
    Task<ChampionshipEntity> GetChampionshipByIdAsync(Guid championshipId);
    Task<bool> TheNameOfTheChampionshipAlreadyExists(string name);
    Task<IEnumerable<ChampionshipEntity>> GetAllChampionshipInProgressAsync();
    Task<ChampionshipEntity> GetChampionshipWithClubsByIdAsync(Guid championshipId);
    Task<List<PlayerEntity>> GetAllPlayersByChampionshipAsync(Guid championshipId, PlayerPosition? position);
    Task UpdateCurrentPhaseAsync(ChampionshipEntity championship);
}
