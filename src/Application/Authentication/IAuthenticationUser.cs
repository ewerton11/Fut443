namespace Application.Authentication;

public interface IAuthenticationUser
{
    Task<string?> AuthenticateUser(string email, string password);
}
