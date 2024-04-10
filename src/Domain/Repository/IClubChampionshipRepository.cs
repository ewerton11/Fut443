namespace Domain.Repository;

public interface IClubChampionshipRepository
{
    Task AddClubToChampionshipAsync(ClubChampionship clubChampionship);
}
