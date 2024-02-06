using Application.DTOs.CreateDTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize(Roles = "root")]
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly CreateAdminUseCase _createAdmin;

    public AdminController(CreateAdminUseCase createAdmin)
    {
        _createAdmin = createAdmin;
    }

    [HttpGet("admin-action")]
    public IActionResult AdminAction()
    {
        return Ok(new { message = "Admin action executed successfully!" });
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAdmin([FromBody] AdminEntityDto adminDto)
    {
        await _createAdmin.CreateAdminAsync(adminDto);

        return Ok(new { message = "User created successfully!" });
    }
}
