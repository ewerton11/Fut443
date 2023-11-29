using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(User user)
    {
        await _userRepository.CreateAsync(user);
        return Ok(new { message = "Usuário criado com sucesso!" });
    }
}
