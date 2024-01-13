using Infrastructure.DTOs;
using Infrastructure.Repository.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserEntityDto userDto)
    {
        await _userRepository.CreateAsync(userDto);
        return Ok(new { message = "User created successfully!" });
    }
}
