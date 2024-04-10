/*
using Application.DTOs.CreateDTOs;
using Application.Interfaces;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/clubChampionship")]
public class ClubChampionshipController : ControllerBase
{
    private readonly IClubChampionshipService _clubChampionshipUseCase;

    public ClubChampionshipController(IClubChampionshipService clubChampionshipUseCase)
    {
        _clubChampionshipUseCase = clubChampionshipUseCase;
    }

    [HttpPost("addClub")]
    public async Task<IActionResult> Associate([FromBody] CreateClubChampionshipDto clubChampionshipDto)
    {
        await _clubChampionshipUseCase.AddClubToChampionshipAsync(clubChampionshipDto);

        return Ok(new { message = "Club e campeonato associado com sucesso!!" });
    }
}
*/