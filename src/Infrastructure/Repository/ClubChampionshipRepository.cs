using Domain.Entities;
using Domain.Repository;

namespace Infrastructure.Repository;

public class ClubChampionshipRepository : IClubChampionshipRepository
{
    private readonly IBaseRepository<ClubChampionship> _baseRepository;

    public ClubChampionshipRepository(IBaseRepository<ClubChampionship> baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public async Task AddClubToChampionshipAsync(ClubChampionship clubChampionship)
    {
        await _baseRepository.CreateAsync(clubChampionship);
    }
}
