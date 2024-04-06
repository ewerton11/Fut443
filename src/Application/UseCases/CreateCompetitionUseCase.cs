using Application.DTOs.CreateDTOs;
using Domain.Aggregates;
using Domain.Repository;

namespace Application.UseCases;

public class CreateCompetitionUseCase
{
    private readonly ICompetitionRepository _competitionRepository;

    public CreateCompetitionUseCase(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }

    public async Task CreateCompetitionAsync(CreateCompetitionDto competitionDto)
    {
        var competition = Competition.CreateCompetition(competitionDto.Title, competitionDto.Value, competitionDto.Championship);

        await _competitionRepository.AddAsync(competition);
    }
}
