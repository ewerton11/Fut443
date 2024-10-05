using Application.DTOs.Championship.CreateChampionship;
using Application.DTOs.Player.ReadPlayer;
using Application.UseCases.Interfaces;
using Application.UseCases.Schedulers;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/championship")]
[ApiController]
public class ChampionshipController : ControllerBase
{
    private readonly ICreateChampionshipUseCase _createChampionshipUseCase;
    private readonly IReadAllChampionshipInProgressUseCase _readAllChampionshipInProgressUseCase;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPlayersChampionshipUseCase _playersChampionshipUseCase;
    private readonly RoundUpdateScheduler _testeee;

    public ChampionshipController(ICreateChampionshipUseCase createChampionshipUseCase,
        IHttpContextAccessor httpContextAccessor, IPlayersChampionshipUseCase playersChampionshipUseCase,
        IReadAllChampionshipInProgressUseCase readAllChampionshipInProgressUseCase, RoundUpdateScheduler testeee)
    {
        _createChampionshipUseCase = createChampionshipUseCase;
        _httpContextAccessor = httpContextAccessor;
        _playersChampionshipUseCase = playersChampionshipUseCase;
        _readAllChampionshipInProgressUseCase = readAllChampionshipInProgressUseCase;
        _testeee = testeee;
    }

    [HasPermission(Permission.HighAdmin)]
    [HttpPost("create")]
    public async Task<IActionResult> CreateChampeionship([FromBody] CreateChampionshipDTO championshipDto)
    {
        var adminIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(adminIdClaim, out var adminId))
        {
            return Unauthorized();
        }

        await _createChampionshipUseCase.CreateChampionshipAsync(adminId, championshipDto);

        return Ok(new { message = "Campeonato criado com sucesso!" });
    }

    [HttpGet("championship/{championshipId}")]
    public async Task<ActionResult<List<ReadPlayerDTO>>> GetPlayersByChampionship(Guid championshipId, [FromQuery] string? position)
    {
        var players = await _playersChampionshipUseCase.GetPlayersByChampionshipAsync(championshipId, position);

        return Ok(players);
    }

    [HttpGet("inProgress")]
    public async Task<IActionResult> GetAllChampionshipInProgress()
    {
        //Remover esse metodo que ta de teste
        await _testeee.UpdateCurrentRoundAsync();

        var listChampionship = await _readAllChampionshipInProgressUseCase.GetAllChampionshipInProgressAsync();

        return Ok(listChampionship);
    }

    /*
    [HttpGet("{id}")]
    public async Task<IActionResult> ChampionshipsWithClubs(Guid id)
    {
        var championship = await _championshipUseCase.GetChampionshipWithClubsByIdAsync(id);

        return Ok(championship);
    }
    */
}
