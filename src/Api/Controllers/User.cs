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

    /*
    [HttpPost("create")]
    public IActionResult CreateUser([FromBody] BaseUserEntityDTO user)
    {
        var createdUser = new BaseUserEntityDTO(
            user.UserName,
            user.Email,
            user.Password,
            user.Role
        );

        return Ok(new { message = "Usuário criado com sucesso!", user = createdUser });
    }
    */

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] BaseUserEntityDto userDTOs)
    {
        await _userRepository.CreateAsync(userDTOs);
        return Ok(new { message = "Usuário criado com sucesso!" });
    }
}
