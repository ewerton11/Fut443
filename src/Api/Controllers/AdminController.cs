using Application.Authentication;
using Application.DTOs.CreateDTOs;
using Application.UseCases;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[HasPermission(Permission.RequireRootRole)]
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly CreateAdminUseCase _createAdmin;
    private readonly IAuthenticationAdmin _authentication;

    public AdminController(CreateAdminUseCase createAdmin, IAuthenticationAdmin authentication)
    {
        _createAdmin = createAdmin;
        _authentication = authentication;
    }

    [HttpGet("test-root")]
    public IActionResult AdminAction()
    {
        return Ok(new { message = "Admin action executed successfully!" });
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAdmin([FromBody] AdminEntityDto adminEntity)
    {
        await _createAdmin.CreateAdminAsync(adminEntity);

        var token = await _authentication.AuthenticateAdmin(adminEntity.Email, adminEntity.Password);

        return Ok(new { message = "Admin created successfully!", token });
    }
}
