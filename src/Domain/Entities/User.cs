using Domain.ValueObjects;

namespace Domain.Entities;

public class User : BaseUserEntity
{
    public Points Points { get; private set; }

    public int Ranking { get; private set; }

    public int FutCoins { get; private set; }

    public User(Guid id, string name, string email, string password, string userName, string role, Points points,
        int ranking, int futCoins)
        : base(id, name, email, password, userName, role)
    {
        Points = points;
        Ranking = ranking;
        FutCoins = futCoins;
    }
}