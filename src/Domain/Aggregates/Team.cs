using Domain.Entities.Base;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Team : BaseEntity
{
    public TeamName Name { get; private set; }
    public Guid TeamId { get; private set; }

    private readonly List<PlayerEntity> _players = new();

    public IReadOnlyList<PlayerEntity> Players => _players.AsReadOnly();

    public Team() { }

    public static Team Create(string name)
    {
        var teamNameResult = TeamName.Create(name);

        var team = new Team
        {
            Name = teamNameResult
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
