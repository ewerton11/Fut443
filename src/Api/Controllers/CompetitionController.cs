using Application.DTOs.Competition;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/competitions")]
[ApiController]
public class CompetitionController : ControllerBase
{
    private readonly ICreateCompetitionUseCase _competitionUseCase;

    public CompetitionController(ICreateCompetitionUseCase competitionUseCase)
    {
        _competitionUseCase = competitionUseCase;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCompetition([FromBody] CreateCompetitionDTO competition)
    {
        await _competitionUseCase.CreateCompetitionAsync(competition);

        return Ok(new { message = "Competition created successfully!" });
    }

    /*
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
 */
}