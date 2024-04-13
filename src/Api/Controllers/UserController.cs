using Application.Authentication;
using Application.DTOs.User.CreateUser;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IAuthenticationUser _authentication;
    private readonly ICreateUserUseCase _createUser;

    public UserController(IAuthenticationUser authentication, ICreateUserUseCase createUser)
    {
        _authentication = authentication;
        _createUser = createUser;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO userDto)
    {
        await _createUser.CreateUserAsync(userDto);

        var token = await _authentication.AuthenticateUser(userDto.Email, userDto.Password);

        return Ok(new { message = "User created successfully!", token });
    }

    /*
    [Authorize(Roles = "common")]
    [HttpGet("read-user-and-team")]
    public async Task<IActionResult> GetUserById()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdString, out var userId))
        {
            return BadRequest(new { message = "Invalid user ID format" });
        }

        var user = await _readUserAndTeam.ReadUserAndTeam(userId);

        return Ok(user);
    }

    [Authorize(Roles = "common")]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userEntity)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdString, out var userId))
        {
            return BadRequest(new { message = "Invalid user ID format" });
        }

        await _updateUser.UpdateUser(userEntity, userId);

        return Ok(new { message = "User updated successfully!" });
    }

    [Authorize(Roles = "common")]
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDto password)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdString, out var userId))
        {
            return BadRequest(new { message = "Invalid user ID format" });
        }

        await _deleteUser.DeleteUser(userId, password.Password);

        return Ok(new { message = "User deleted successfully!" });
    }
    */
}