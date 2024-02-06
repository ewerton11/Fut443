using Domain.Enums;

namespace Application.Service;

public interface IJwtTokenService
{
    string GenerateToken(Guid id, string name, UserRole role);
}
