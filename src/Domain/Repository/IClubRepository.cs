namespace Domain.Repository;

public interface IClubRepository
{
    Task AddClubAsync(ClubEntity club);
    Task<ClubEntity> GetClubByIdAsync(Guid clubId);
}
