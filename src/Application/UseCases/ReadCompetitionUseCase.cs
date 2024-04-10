/*
using Domain.Repository;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.UseCases;

public class ReadCompetitionUseCase
{
    private readonly ICompetitionRepository _competitionRepository;

    public ReadCompetitionUseCase(ICompetitionRepository competitionRepository)
    {
        _competitionRepository = competitionRepository;
    }

    public async Task<string?> ReadTeams(Guid id)
    {
        var competition = await _competitionRepository.GetByIdAsync(id);

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        var jsonString = JsonSerializer.Serialize(competition, options);
        return jsonString;
    }

    public async Task<string?> ReadTeamss()
    {
        var competition = await _competitionRepository.GetAllAsync();

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        var jsonString = JsonSerializer.Serialize(competition, options);
        return jsonString;
    }
}
*/