using Application.DTOs.Club.CreateClub;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/club")]
[ApiController]
public class ClubController : ControllerBase
{
    private readonly ICreateClubUseCase _clubUseCase;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClubController(ICreateClubUseCase clubUseCase, IHttpContextAccessor httpContextAccessor)
    {
        _clubUseCase = clubUseCase;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateClubDTO clubDto)
    {
        var adminIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(adminIdClaim, out var adminId))
        {
            return Unauthorized();
        }

        await _clubUseCase.CreateClubAsync(clubDto, adminId);

        return Ok(new { message = "Club criado com sucesso!!" });
    }
}