namespace Application.Authentication;

public interface IAuthenticationAdmin
{
    Task<string?> AuthenticateAdmin(string email, string password);
}
