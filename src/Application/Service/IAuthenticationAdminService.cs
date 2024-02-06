namespace Application.Service;

public interface IAuthenticationAdminService
{
    Task<string?> AuthenticateAdmin(string email, string password);
}
