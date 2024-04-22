using Application.DTOs.Team.CreateTeam;
using Application.UseCases.Interfaces;
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

    public TeamController(ICreateTeamUseCase teamUseCase, IAddPlayerToTeamUseCase addPlayerToTeamUseCase, 
        IHttpContextAccessor httpContextAccessor)
    {
        _teamUseCase = teamUseCase;
        _addPlayerToTeamUseCase = addPlayerToTeamUseCase;
        _httpContextAccessor = httpContextAccessor;
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