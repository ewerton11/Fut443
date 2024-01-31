using Application.DTOs;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserEntityDto userDto)
    {
        await _userService.CreateUser(userDto);

        return Ok(new { message = "User created successfully!" });
    }
}
