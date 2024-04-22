namespace Domain.Repository;

public interface IClubChampionshipRepository
{
    Task AddClubToChampionshipAsync(ClubChampionship clubChampionship);
    Task<ClubChampionship?> GetByClubIdAndChampionshipIdAsync(Guid? clubId, Guid championshipId);
}
