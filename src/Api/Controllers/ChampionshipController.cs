using Application.DTOs.Championship.CreateChampionship;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/championship")]
[ApiController]
public class ChampionshipController : ControllerBase
{
    private readonly ICreateChampionshipUseCase _createChampionshipUseCase;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ChampionshipController(ICreateChampionshipUseCase createChampionshipUseCase, IHttpContextAccessor httpContextAccessor)
    {
        _createChampionshipUseCase = createChampionshipUseCase;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("create")]
    [Authorize(Roles = "HighAdmin")]
    public async Task<IActionResult> CreateChampeionship([FromBody] CreateChampionshipDTO championshipDto)
    {
        var adminIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(adminIdClaim, out var adminId))
        {
            return Unauthorized();
        }

        await _createChampionshipUseCase.CreateChampionshipAsync(championshipDto, adminId);

        return Ok(new { message = "Campeonato criado com sucesso!" });
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
