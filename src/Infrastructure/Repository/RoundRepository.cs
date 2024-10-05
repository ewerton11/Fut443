using Domain.Aggregates;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class RoundRepository : IRoundRepository
{
    private readonly IBaseRepository<Round> _baseRepository;
    private readonly DataContext _dataContext;

    public RoundRepository(IBaseRepository<Round> baseRepository, DataContext dataContext)
    {
        _baseRepository = baseRepository;
        _dataContext = dataContext;
    }

    public async Task CreateRoundAsync(Round round)
    {
        await _baseRepository.CreateAsync(round);
    }

    public async Task<Round> GetRoundByChampionshipIdAndPhaseAsync(Guid championshipId, int currentPhase)
    {
        var round = await _dataContext.Round.FirstOrDefaultAsync(r => r.ChampionshipId == championshipId && r.Number == currentPhase);

        return round ?? throw new Exception("Round not found for the specified championshipId and phase.");
    }
}
