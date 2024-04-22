using Domain.Repository;
using Domain.ValueObject;

namespace Application.Authentication;

public class AuthenticationUser : IAuthenticationUser
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IJwtTokenService _tokenService;

    public AuthenticationUser(IUserRepository userRepository, IPasswordHashService passwordHashService,
        IJwtTokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _passwordHashService = passwordHashService;
    }

    public async Task<string?> AuthenticateUser(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(Email.Create(email));

        if (user != null && _passwordHashService.VerifyPassword(password, user.PasswordHash))
        {
            return _tokenService.GenerateToken(user.Id, user.FirstName.Value, null);
        }

        return null;
    }
}
