using Application.DTOs.Competition;
using Application.UseCases.Interfaces;
using Domain.Aggregates;
using Domain.Repository;

namespace Application.UseCases.CompetitionUseCase;

public class CreateCompetitionUseCase : ICreateCompetitionUseCase
{
    private readonly ICompetitionRepository _competitionRepository;

    public CreateCompetitionUseCase(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }

    public async Task CreateCompetitionAsync(CreateCompetitionDTO competitionDto)
    {
        var competition = Competition.CreateCompetition(competitionDto.Title, competitionDto.Value, competitionDto.ChampionshipId);

        await _competitionRepository.AddCompetitionAsync(competition);
    }
}