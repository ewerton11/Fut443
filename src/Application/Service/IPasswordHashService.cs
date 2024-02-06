namespace Application.Service;

public interface IPasswordHashService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash);
}