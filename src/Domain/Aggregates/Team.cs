namespace Domain.Aggregates;

public class Team : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public Guid TeamId { get; set; }

    private readonly List<PlayerEntity> _players = new();

    public IReadOnlyList<PlayerEntity> Players => _players.AsReadOnly();

    public Team(string name)
    {
        Name = name;
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
