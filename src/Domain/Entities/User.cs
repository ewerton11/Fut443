using Domain.ValueObject;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : BaseUserEntity
{
    public Points Points { get; private set; }

    public int Ranking { get; private set; }

    public int FutCoins { get; private set; }

    public User(UserName userName, Email email, string password, string role,
        Points points, int ranking, int futCoins)
        : base(userName, email, password, role)
    {
        Points = points;
        Ranking = ranking;
        FutCoins = futCoins;
    }
}