using Application.DTOs.Player.CreatePlayer;
using Application.UseCases.Interfaces;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[HasPermission(Permission.HighAdmin)]
[ApiController]
[Route("api/player")]
public class PlayerController : ControllerBase
{
    private readonly ICreatePlayerUseCase _playerUseCase;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PlayerController(ICreatePlayerUseCase playerUseCase, IHttpContextAccessor httpContextAccessor)
    {
        _playerUseCase = playerUseCase;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerDTO playerDto)
    {
        var adminIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(adminIdClaim, out var adminId))
        {
            return Unauthorized();
        }

        await _playerUseCase.CreatePlayerAsync(playerDto, adminId);

        return Ok(new { message = "player created successfully!" });
    }
}