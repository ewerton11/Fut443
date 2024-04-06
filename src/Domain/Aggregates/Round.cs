using Domain.Entities.Base;

namespace Domain.Aggregates;

public class Round : BaseEntity
{
    public int Number { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public List<Match> Matches { get; private set; }

    private Round() { }

    public static Round Create(int number, DateTime startDate, DateTime EndDate)
    {
        var round = new Round
        {
            Number = number,
            StartDate = startDate,
            EndDate = EndDate,
            Matches = new List<Match>()
        };

        return round;
    }

    public void AddMatch(Club homeTeam, Club awayTeam, DateTime matchDate, int homeTeamScore = 0,
        int awayTeamScore = 0, string status = "Scheduled")
    {
        Matches.Add(Match.Create(homeTeam, awayTeam, matchDate, homeTeamScore, awayTeamScore, status));
    }
}
