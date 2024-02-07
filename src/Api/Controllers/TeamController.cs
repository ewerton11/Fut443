using Application.DTOs.CreateDTOs;
using Application.UseCases;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[Authorize(Roles = "common")]
[ApiController]
[Route("api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly CreateTeamUseCase _createTeamUseCase;

    public TeamController(CreateTeamUseCase createTeamUseCase)
    {
        _createTeamUseCase = createTeamUseCase;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePlayer([FromBody] CreateTeamDto teamDto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdString, out var userId))
        {
            return BadRequest(new { message = "Invalid user ID format" });
        }

        await _createTeamUseCase.CreateTeam(teamDto.Name, userId);

        return Ok(new { message = "team created successfully!" });
    }
}
