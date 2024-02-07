using Domain.Entities.Base;

namespace Domain.Aggregates;

public class Championship : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    private readonly List<Team> _team = new();

    public IReadOnlyList<Team> Teams => _team.AsReadOnly();

    public Championship() { }

    public static Championship Create(string name)
    {
        var championship = new Championship
        {
            Name = name
        };

        return championship;
    }
}
