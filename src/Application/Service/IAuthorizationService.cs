namespace Application.Service;

public interface IAuthorizationService
{
    bool CanCreateUser(string requestingUserId);
}
