using Domain.Entities.Base;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Team : BaseEntity
{
    public TeamName Name { get; private set; } = null!;

    public List<PlayerEntity> Players { get; private set; } = null!;

    public Guid UserId { get; private set; }

    public UserEntity User { get; private set; } = null!;

    public Guid ChampionshipId { get; private set; }

    public ChampionshipEntity Championship { get; private set; } = null!;

    public Team() { }

    public static Team Create(string name, Guid userId)
    {
        var teamNameResult = TeamName.Create(name);

        var team = new Team
        {
            Name = teamNameResult,
            UserId = userId
        };

        return team;
    }
}
