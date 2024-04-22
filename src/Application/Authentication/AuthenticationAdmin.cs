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
        _passwordHashService = passwordHashService;
        _tokenService = tokenService;
    }

    public async Task<string?> AuthenticateAdmin(string email, string password)
    {
        var admin = await _adminRepository.GetAdminByEmailAsync(Email.Create(email));

        if (admin != null && _passwordHashService.VerifyPassword(password, admin.PasswordHash))
        {
            return _tokenService.GenerateToken(admin.Id, admin.FirstName.Value, admin.Level);
        }

        return null;
    }
}
