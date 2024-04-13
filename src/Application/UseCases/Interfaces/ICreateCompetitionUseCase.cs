using Application.DTOs.Competition;

namespace Application.UseCases.Interfaces;

public interface ICreateCompetitionUseCase
{
    Task CreateCompetitionAsync(CreateCompetitionDTO competitionDto);
}
