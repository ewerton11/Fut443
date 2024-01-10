using Domain.ValueObject;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : BaseUserEntity
{
    public Points Points { get; private set; }

    public int Ranking { get; private set; }

    public int FutCoins { get; private set; }

    public User(Name name, string email, string password, string userName, string role,
        Points points, int ranking, int futCoins)
        : base(name, email, password, userName, role)
    {
        Points = points;
        Ranking = ranking;
        FutCoins = futCoins;
    }
}