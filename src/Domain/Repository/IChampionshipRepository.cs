namespace Domain.Repository;

public interface IChampionshipRepository
{
    Task AddChampionshipAsync(ChampionshipEntity championship);
    Task<ChampionshipEntity> GetChampionshipByIdAsync(Guid championshipId);
    Task<ChampionshipEntity> GetChampionshipWithClubsByIdAsync(Guid championshipId);
}
