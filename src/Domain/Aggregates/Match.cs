using Domain.Entities.Base;

namespace Domain.Aggregates;

public class Match : BaseEntity
{
    public DateTime MatchDate { get; private set; }
    public Club HomeTeam { get; private set; }
    public Club AwayTeam { get; private set; }
    public int HomeTeamScore { get; private set; }
    public int AwayTeamScore { get; private set; }
    public string Status { get; private set; }

    private Match() { }

    public static Match Create(Club homeTeam, Club awayTeam, DateTime matchDate, int homeTeamScore = 0,
        int awayTeamScore = 0, string status = "Scheduled")
    {
        return new Match
        {
            MatchDate = matchDate,
            HomeTeam = homeTeam,
            AwayTeam = awayTeam,
            HomeTeamScore = homeTeamScore,
            AwayTeamScore = awayTeamScore,
            Status = status
        };
    }
}
