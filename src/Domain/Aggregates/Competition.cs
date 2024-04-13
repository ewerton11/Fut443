using Domain.Entities.Base;

namespace Domain.Aggregates;

public class Competition : BaseEntity
{
    public string Title { get; private set; } = null!;

    public decimal Value { get; private set; }

    public Guid ChampionshipId { get; private set; }
    public ChampionshipEntity Championship { get; private set; } = null!;

    public List<Team>? Teams { get; private set; }

    private Competition() { }

    public static Competition CreateCompetition(string title, decimal value, Guid championshipId)
    {
        var competition = new Competition
        {
            Title = title,
            Value = value,
            ChampionshipId = championshipId
        };

        return competition;
    }
}
