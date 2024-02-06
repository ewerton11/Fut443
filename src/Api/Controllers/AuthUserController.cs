using Application.Authentication;
using Application.DTOs.Login;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthUserController : ControllerBase
{
    private readonly IAuthenticationUser _authentication;

    public AuthUserController(IAuthenticationUser authentication)
    {
        _authentication = authentication;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserEntityDto userEntity)
    {
        var user = await _authentication.AuthenticateUser(userEntity.Email, userEntity.Password);

        if (user == null)
            return Unauthorized(new { Message = "Incorrect email or password" });

        return Ok(new { User = user });
    }
}