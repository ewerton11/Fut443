﻿using Application.DTOs.Championship.CreateChampionship;
using Application.DTOs.Player.ReadPlayer;
using Application.UseCases.Interfaces;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/championship")]
[ApiController]
public class ChampionshipController : ControllerBase
{
    private readonly ICreateChampionshipUseCase _createChampionshipUseCase;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPlayersChampionshipUseCase _playersChampionshipUseCase;

    public ChampionshipController(ICreateChampionshipUseCase createChampionshipUseCase,
        IHttpContextAccessor httpContextAccessor, IPlayersChampionshipUseCase playersChampionshipUseCase)
    {
        _createChampionshipUseCase = createChampionshipUseCase;
        _httpContextAccessor = httpContextAccessor;
        _playersChampionshipUseCase = playersChampionshipUseCase;
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

        await _createChampionshipUseCase.CreateChampionshipAsync(championshipDto, adminId);

        return Ok(new { message = "Campeonato criado com sucesso!" });
    }

    [HttpGet("championship/{championshipId}")]
    public async Task<ActionResult<List<ReadPlayerDTO>>> GetPlayersByChampionship(Guid championshipId)
    {
        var players = await _playersChampionshipUseCase.GetPlayersByChampionshipAsync(championshipId);

        return Ok(players);
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
