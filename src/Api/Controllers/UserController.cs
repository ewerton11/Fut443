using Application.DTOs.CreateDTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/*
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly CreateUserUseCase _createUser;

    public UserController(CreateUserUseCase createUser)
    {
        _createUser = createUser;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserEntityDto userDto)
    {
        await _createUser.CreateUserAsync(userDto);

        return Ok(new { message = "User created successfully!" });
    }
}
*/
