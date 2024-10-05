using Domain.Aggregates;
using Domain.Entities;
using Domain.Repository;

namespace Application.UseCases.Schedulers;

public class RoundUpdateScheduler
{
    private readonly IChampionshipRepository _championshipRepository;
    private readonly IRoundRepository _roundRepository;

    public RoundUpdateScheduler(IChampionshipRepository championshipRepository, IRoundRepository roundRepository)
    {
        _championshipRepository = championshipRepository;
        _roundRepository = roundRepository;
    }

    public async Task UpdateCurrentRoundAsync()
    {
        IEnumerable<ChampionshipEntity?> allChampionshipInProgress = await _championshipRepository.GetAllChampionshipInProgressAsync();

        foreach (ChampionshipEntity? championship in allChampionshipInProgress)
        {
            if (championship != null)
            {
                Round round = await _roundRepository.GetRoundByChampionshipIdAndPhaseAsync(championship.Id, championship.CurrentPhase);

                if (DateTime.Now > round.EndDate)
                {
                    championship.UpdateCurrentPhase();

                    await _championshipRepository.UpdateCurrentPhaseAsync(championship);
                }
            }
        }
    }
}
