using Application.DTOs;
using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    //private readonly TokenService _tokenService;

    public AuthController(UserService userService /* , TokenService tokenService*/)
    {
        _userService = userService;
       // _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserCredentialsDto credentials)
    {
        // Lógica de autenticação e verificação de credenciais
        if (await _userService.AuthenticateUser(credentials.Email, credentials.Password))
        {
            // Gera um token JWT
            var token = "tokenFoda-se";
                //_tokenService.GenerateToken(credentials);

            // Retorna o token para o cliente
            return Ok(new { Token = token });
        }

        // Retorna um erro caso as credenciais sejam inválidas
        return Unauthorized(new { Message = "Credenciais inválidas" });
    }
}
