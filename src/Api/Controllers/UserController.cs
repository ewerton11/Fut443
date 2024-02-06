using Application.Authentication;
using Application.DTOs.CreateDTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly CreateUserUseCase _createUser;
    private readonly IAuthenticationUser _authentication;

    public UserController(CreateUserUseCase createUser, IAuthenticationUser authentication)
    {
        _createUser = createUser;
        _authentication = authentication;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserEntityDto userEntity)
    {
        await _createUser.CreateUserAsync(userEntity);

        var token = await _authentication.AuthenticateUser(userEntity.Email, userEntity.Password);

        return Ok(new { message = "User created successfully!", token });
    }
}
