using Application.DTOs.CreateDTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/competitions")]
[ApiController]
public class CompetitionController : ControllerBase
{
    private readonly CreateCompetitionUseCase _createCompetition;
    private readonly ReadCompetitionUseCase _readCompetitionUseCase;

    public CompetitionController(CreateCompetitionUseCase createCompetition, ReadCompetitionUseCase readCompetitionUseCase)
    {
        _createCompetition = createCompetition;
        _readCompetitionUseCase = readCompetitionUseCase;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCompetition([FromBody] CreateCompetitionDto competition)
    {
        await _createCompetition.CreateCompetitionAsync(competition);

        return Ok(new { message = "Competition created successfully!" });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetComp(Guid id)
    {
        var competition = await _readCompetitionUseCase.ReadTeams(id);

        return Ok(competition);
    }

    [HttpGet]
    public async Task<IActionResult> GetComp()
    {
        var competition = await _readCompetitionUseCase.ReadTeamss();

        return Ok(competition);
    }
}
