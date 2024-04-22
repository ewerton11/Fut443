using Domain.Entities;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ClubChampionshipRepository : IClubChampionshipRepository
{
    private readonly IBaseRepository<ClubChampionship> _baseRepository;
    private readonly DataContext _dbContext;

    public ClubChampionshipRepository(IBaseRepository<ClubChampionship> baseRepository, DataContext dbContext)
    {
        _baseRepository = baseRepository;
        _dbContext = dbContext;
    }

    public async Task AddClubToChampionshipAsync(ClubChampionship clubChampionship)
    {
        await _baseRepository.CreateAsync(clubChampionship);
    }

    public async Task<ClubChampionship?> GetByClubIdAndChampionshipIdAsync(Guid? clubId, Guid championshipId)
    {
        var clubChampionship = await _dbContext.ClubChampionship.FirstOrDefaultAsync(cc =>
            cc.ClubId == clubId && cc.ChampionshipId == championshipId);

        return clubChampionship;
    }
}
