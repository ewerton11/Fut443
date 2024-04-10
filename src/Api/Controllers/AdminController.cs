using Application.Authentication;
using Application.DTOs.Admin;
using Application.UseCases.Interfaces;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers;

//[HasPermission(Permission.HighAdmin)]
[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly ICreateAdminUseCase _createAdmin;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAuthenticationAdmin _authentication;

    public AdminController(ICreateAdminUseCase createAdmin, IHttpContextAccessor httpContextAccessor, IAuthenticationAdmin authentication)
    {
        _createAdmin = createAdmin;
        _httpContextAccessor = httpContextAccessor;
        _authentication = authentication;
    }

    [HttpGet("test-root")]
    public IActionResult AdminAction()
    {
        return Ok(new { message = "Admin action executed successfully!" });
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminDTO adminDto)
    {
        var adminIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(adminIdClaim, out var adminId))
        {
            return Unauthorized();
        }

        await _createAdmin.CreateAdminAsync(adminDto, adminId);

        var token = await _authentication.AuthenticateAdmin(adminDto.Email, adminDto.Password);

        return Ok(new { message = "Admin created successfully!", token });
    }
}