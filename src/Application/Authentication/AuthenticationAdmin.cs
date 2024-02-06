using Domain.Repository;
using Domain.ValueObject;

namespace Application.Authentication;

public class AuthenticationAdmin : IAuthenticationAdmin
{
    private readonly IAdminRepository _adminRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IJwtTokenService _tokenService;

    public AuthenticationAdmin(IAdminRepository adminRepository, IPasswordHashService passwordHashService,
        IJwtTokenService tokenService)
    {
        _adminRepository = adminRepository;
        _tokenService = tokenService;
        _passwordHashService = passwordHashService;
    }

    public async Task<string?> AuthenticateAdmin(string email, string password)
    {
        var user = await _adminRepository.GetUserByEmailAsync(Email.Create(email));

        if (user != null && _passwordHashService.VerifyPassword(password, user.PasswordHash))
        {
            return _tokenService.GenerateToken(user.Id, user.Name, user.Role);
        }

        return null;
    }
}
