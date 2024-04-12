using Application.DTOs.ClubChampionship;
using Application.UseCases.Interfaces;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[HasPermission(Permission.HighAdmin)]
[ApiController]
[Route("api/clubChampionship")]
public class ClubChampionshipController : ControllerBase
{
    private readonly IAddClubToChampionshipUseCase _clubChampionship;

    public ClubChampionshipController(IAddClubToChampionshipUseCase clubChampionship)
    {
        _clubChampionship = clubChampionship;
    }

    [HttpPost("associate")]
    public async Task<IActionResult> Associate([FromBody] AddClubToChampionshipDTO clubChampionshipDto)
    {
        await _clubChampionship.AddClubToChampionship(clubChampionshipDto);

        return Ok(new { message = "Club e campeonato associado com sucesso!!" });
    }
}