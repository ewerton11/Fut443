using Application.Service;

namespace Infrastructure.Service;

public class AuthorizationService : IAuthorizationService
{
    private readonly IJwtTokenService _jwtTokenService;

    public AuthorizationService(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    public bool CanCreateUser(string requestingUserId)
    {
        throw new NotImplementedException();
    }
}
