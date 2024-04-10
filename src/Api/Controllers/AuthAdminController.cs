using Application.Authentication;
using Application.DTOs.Login;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/admin/auth")]
public class AuthAdminController : ControllerBase
{
    private readonly IAuthenticationAdmin _authentication;

    public AuthAdminController(IAuthenticationAdmin authentication)
    {
        _authentication = authentication;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserEntityDto userEntity)
    {
        var token = await _authentication.AuthenticateAdmin(userEntity.Email, userEntity.Password);

        if (token == null)
            return Unauthorized(new { Message = "Incorrect email or password" });

        return Ok(new { Token = token });
    }
}