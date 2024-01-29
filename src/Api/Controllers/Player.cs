using Infrastructure.DTOs;
using Infrastructure.Repository.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerRepository _playerRepository;

    public PlayerController(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] CreatePlayerEntityDto playerDto)
    {
        await _playerRepository.CreateAsync(playerDto);
        return Ok(new { message = "Player created successfully!" });
    }
}
