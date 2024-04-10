using Domain.Entities.Base;

namespace Domain.Aggregates;

public class Round : BaseEntity
{
    public int Number { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Guid ChampionshipId { get; private set; }
    public ChampionshipEntity Championship { get; private set; } = null!;
    public List<Match> Matches { get; private set; }

    private Round() 
    {
        Matches = new List<Match>();
    }

    public static Round Create(int number, DateTime startDate, DateTime EndDate, Guid championshipId)
    {
        var round = new Round
        {
            Number = number,
            StartDate = startDate,
            EndDate = EndDate,
            ChampionshipId = championshipId
        };

        return round;
    }

    public void AddMatch(Match match)
    {
        Matches.Add(match);
    }
}
