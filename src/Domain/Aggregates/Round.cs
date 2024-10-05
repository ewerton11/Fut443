using Domain.Entities.Base;

namespace Domain.Aggregates;

public class Round : BaseEntity
{
    public int Number { get; private set; }
    public int Season { get; private set; }
    public bool IsTeamBuildingClosed { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Guid ChampionshipId { get; private set; }
    public ChampionshipEntity Championship { get; private set; } = null!;
    public List<Match> Matches { get; private set; } = new List<Match>();

    private Round() { }

    public static Round Create(int number, int season, Guid championshipId)
    {
        var round = new Round
        {
            Number = number,
            Season = season,
            ChampionshipId = championshipId
        };

        return round;
    }
}
