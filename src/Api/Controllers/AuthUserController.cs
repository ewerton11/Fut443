using Application.DTOs.Login;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/*
[ApiController]
[Route("api/[controller]")]
public class AuthUserController : ControllerBase
{
    private readonly IAuthenticationUserService _authenticationService;

    public AuthUserController(IAuthenticationUserService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserEntityDto userEntity)
    {
        var user = await _authenticationService.AuthenticateUser(userEntity.Email, userEntity.Password);

        if (user == null)
            return Unauthorized(new { Message = "Incorrect email or password" });

        return Ok(new { User = user });
    }
}
*/