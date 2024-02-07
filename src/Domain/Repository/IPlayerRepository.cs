namespace Domain.Repository;

public interface IPlayerRepository
{
Task<bool> IsPlayerInClubAsync(string name, string club);
}
