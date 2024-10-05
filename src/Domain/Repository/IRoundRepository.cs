using Domain.Aggregates;

namespace Domain.Repository;

public interface IRoundRepository
{
    Task CreateRoundAsync(Round round);
    Task<Round> GetRoundByChampionshipIdAndPhaseAsync(Guid championshipId, int currentPhase);
}
