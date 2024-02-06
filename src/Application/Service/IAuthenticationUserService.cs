namespace Application.Service;

public interface IAuthenticationUserService
{
    Task<string?> AuthenticateUser(string email, string password);
}
