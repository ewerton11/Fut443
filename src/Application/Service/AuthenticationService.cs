/*
using Domain.Services;
using Infrastructure.Repository.Abstractions;

public class AuthenticationService
{
    private readonly IUserAuthenticationService _userAuthenticationService;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthenticationService(IUserAuthenticationService userAuthenticationService, IJwtTokenService jwtTokenService)
    {
        _userAuthenticationService = userAuthenticationService;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<string> AuthenticateUserAsync(string email)
    {
        // Lógica de autenticação
        var user = await _userAuthenticationService.GetEmailAsync(email);

        if (user != null && VerifyPassword(user, password))
        {
            // Geração do token JWT
            var token = _jwtTokenService.GenerateToken(user);
            return token;
        }

        return null;
    }

    private bool VerifyPassword(string email, string password)
    {
        // Lógica de verificação de senha
        // Implemente de acordo com suas regras de segurança
        // (hashing, comparação segura, etc.)
        return user.Password == password;
    }
}
*/