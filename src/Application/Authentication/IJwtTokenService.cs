using Domain.Enums;

namespace Application.Authentication;

public interface IJwtTokenService
{
    string GenerateToken(Guid id, string firstName, AdminLevel? level);
}
