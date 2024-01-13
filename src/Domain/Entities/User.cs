﻿using Domain.ValueObject;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : BaseUserEntity
{
    public Points Points { get; private set; }

    public int Ranking { get; private set; }

    public int FutCoins { get; private set; }

    protected User() : base(UserName.Create("nome"), Email.Create("email@email.com"), string.Empty, string.Empty)
    {
        Points = new Points();
    }

    public User(UserName userName, Email email, string password, string role,
        Points points, int ranking = 0, int futCoins = 0)
        : base(userName, email, password, role)
    {
        Points = points ?? new Points();
        Ranking = ranking;
        FutCoins = futCoins;
    }
}