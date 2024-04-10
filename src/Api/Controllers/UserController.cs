/*
using Application.Authentication;
using Application.DTOs;
using Application.DTOs.CreateDTOs;
using Application.DTOs.UpdateDTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly CreateUserUseCase _createUser;
    private readonly ReadUserUseCase _readUserAndTeam;
    private readonly IAuthenticationUser _authentication;
    private readonly UpdateUserUseCase _updateUser;
    private readonly DeleteUserUseCase _deleteUser;

    public UserController(CreateUserUseCase createUser, ReadUserUseCase readUserUseCase, IAuthenticationUser authentication,
        UpdateUserUseCase updateUser, DeleteUserUseCase deleteUser)
    {
        _createUser = createUser;
        _readUserAndTeam = readUserUseCase;
        _authentication = authentication;
        _updateUser = updateUser;
        _deleteUser = deleteUser;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserEntityDto userEntity)
    {
        await _createUser.CreateUserAsync(userEntity);

        var token = await _authentication.AuthenticateUser(userEntity.Email, userEntity.Password);

        return Ok(new { message = "User created successfully!", token });
    }

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
}
*/