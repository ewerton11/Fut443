using Domain.Entities.Base;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Team : BaseEntity
{
    public TeamName Name { get; private set; }

    private readonly List<PlayerEntity> _players = new();

    public IReadOnlyList<PlayerEntity> Players => _players.AsReadOnly();

    public Guid UserId { get; private set; }

    public UserEntity User { get; private set; }

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

    public void AddPlayer(PlayerEntity player)
    {
        _players.Add(player);
    }

    public void RemovePlayer(PlayerEntity player)
    {
        _players.Remove(player);
    }

    public List<PlayerEntity> GetPlayers()
    {
        return _players;
    }
}
