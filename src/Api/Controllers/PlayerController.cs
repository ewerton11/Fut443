/*
using Application.DTOs.CreateDTOs;
using Application.UseCases;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[HasPermission(Permission.RequireRootRole)]
[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly CreatePlayerUseCase _createPlayerUseCase;

    public PlayerController(CreatePlayerUseCase createPlayerUseCase)
    {
        _createPlayerUseCase = createPlayerUseCase;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePlayer([FromBody] PlayerEntityDto playerDto)
    {
        await _createPlayerUseCase.CreatePlayer(playerDto.Name, playerDto.Position, playerDto.Club);

        return Ok(new { message = "player created successfully!"});
    }
}
*/