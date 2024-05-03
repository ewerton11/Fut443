using Application.DTOs.Player.ReadPlayer;
using Application.DTOs.Team.CreateTeam;
using Application.UseCases.Interfaces;
using Application.UseCases.TeamUseCase.CreateTeam;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[ApiController]
[Route("api/team")]
public class TeamController : ControllerBase
{
    private readonly ICreateTeamUseCase _teamUseCase;
    private readonly IAddPlayerToTeamUseCase _addPlayerToTeamUseCase;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly CriarTimeTemporarioUseCase _criarTimeTemporarioUseCase;

    public TeamController(ICreateTeamUseCase teamUseCase, IAddPlayerToTeamUseCase addPlayerToTeamUseCase,
        IHttpContextAccessor httpContextAccessor, CriarTimeTemporarioUseCase criarTimeTemporarioUseCase)
    {
        _teamUseCase = teamUseCase;
        _addPlayerToTeamUseCase = addPlayerToTeamUseCase;
        _httpContextAccessor = httpContextAccessor;
        _criarTimeTemporarioUseCase = criarTimeTemporarioUseCase;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePlayer([FromBody] CreateTeamDTO teamDto, Guid championshipId)
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized();
        }

        await _teamUseCase.CreateTeamAsync(teamDto, userId, championshipId);

        return Ok(new { message = "team created successfully!" });
    }

    [HttpPost("temporary/create/{championshipId}")]
    public async Task<IActionResult> CreatePlayerTemporary(Guid championshipId, [FromBody] List<Guid> playerIds)
    {
        if (playerIds == null || playerIds.Count == 0)
        {
            return BadRequest("Nenhum jogador foi fornecido.");
        }

        var listPlayers = await _criarTimeTemporarioUseCase.CriarTimeTemporario(championshipId, playerIds);

        return Ok(listPlayers);
    }

    [HttpPost("addPlayer/{championshipId}/{teamId}/{playerId}")]
    public async Task<IActionResult> AddPlayer(Guid championshipId, Guid teamId, Guid playerId)
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized();
        }

        await _addPlayerToTeamUseCase.AddPlayerToTeamAsync(userId, championshipId, teamId, playerId);

        return Ok(new { message = "player inserido successfully!" });
    }
}