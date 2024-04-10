using Domain.Entities.Base;

namespace Domain.Aggregates;

public class Competition : BaseEntity
{
    public string Title { get; private set; }

    public decimal Value { get; private set; }

    public ChampionshipEntity Championship { get; private set; }

    private readonly List<Team> _team = new();

    public IReadOnlyList<Team> Teams => _team.AsReadOnly();

    private Competition() { }

    public static Competition CreateCompetition(string title, decimal value, ChampionshipEntity championship)
    {
        var competition = new Competition
        {
            Title = title,
            Value = value,
            Championship = championship
        };

        return competition;
    }
}
