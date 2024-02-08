using Application.Authentication;
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
    private readonly IAuthenticationUser _authentication;
    private readonly UpdateUserUseCase _updateUser;

    public UserController(CreateUserUseCase createUser, IAuthenticationUser authentication, UpdateUserUseCase updateUser)
    {
        _createUser = createUser;
        _authentication = authentication;
        _updateUser = updateUser;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserEntityDto userEntity)
    {
        await _createUser.CreateUserAsync(userEntity);

        var token = await _authentication.AuthenticateUser(userEntity.Email, userEntity.Password);

        return Ok(new { message = "User created successfully!", token });
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

        return Ok(new { message = "User updated successfully!"});
    }
}
