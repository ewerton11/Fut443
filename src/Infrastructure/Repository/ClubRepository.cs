using Domain.Entities;
using Domain.Repository;

namespace Infrastructure.Repository;

public class ClubRepository : IClubRepository
{
    private readonly IBaseRepository<ClubEntity> _baseRepository;

    public ClubRepository(IBaseRepository<ClubEntity> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task AddClubAsync(ClubEntity club)
    {
        await _baseRepository.CreateAsync(club);
    }

    public async Task<ClubEntity> GetClubByIdAsync(Guid clubId)
    {
        var club = await _baseRepository.GetByIdAsync(clubId);

        return club;
    }
}
