using Domain.Entities;
using Infrastructure.Repository;
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
    public async Task<IActionResult> CreateUser(User user)
    {
        await _userRepository.CreateAsync(user);
        return Ok(new { message = "Usuário criado com sucesso!" });
    }
}
