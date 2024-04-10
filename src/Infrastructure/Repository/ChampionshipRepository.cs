using Domain.Aggregates;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ChampionshipRepository : IChampionshipRepository
{
    private readonly IBaseRepository<ChampionshipEntity> _baseRepository;
    private readonly DataContext _dbContext;

    public ChampionshipRepository(IBaseRepository<ChampionshipEntity> baseRepository, DataContext dbContext)
    {
        _baseRepository = baseRepository;
        _dbContext = dbContext;
    }

    public async Task AddChampionshipAsync(ChampionshipEntity championship)
    {
        await _baseRepository.CreateAsync(championship);
    }

    public async Task<ChampionshipEntity> GetChampionshipByIdAsync(Guid championshipId)
    {
        var championship = await _baseRepository.GetByIdAsync(championshipId);

        return championship;
    }

    public async Task<ChampionshipEntity> GetChampionshipWithClubsByIdAsync(Guid championshipId)
    {
        var championshipsWithClubs = await _dbContext.Championship
            .Include(champ => champ.ClubChampionships)
            .ThenInclude(cc => cc.Club)
             .FirstOrDefaultAsync(champ => champ.Id == championshipId);

        return championshipsWithClubs ?? throw new Exception($"Championship with ID {championshipId} not found.");
    }
}
