using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Aggregates;

public class Match : BaseEntity
{
    public DateTime MatchDate { get; private set; }
    public Guid HomeTeamId { get; private set; }
    public ClubEntity HomeTeam { get; private set; } = null!;
    public Guid AwayTeamId { get; private set; }
    public ClubEntity AwayTeam { get; private set; } = null!;
    public int HomeTeamScore { get; private set; }
    public int AwayTeamScore { get; private set; }
    public MatchStatus Status { get; private set; }
    public Guid RoundId { get; private set; }
    public Round Round { get; private set; } = null!;

    private Match() { }

    public static Match Create(DateTime matchDate, Guid homeTeamId, Guid awayTeamId, int homeTeamScore, int awayTeamScore, MatchStatus status, Guid roundId)
    {
        var match = new Match
        {
            MatchDate = matchDate,
            HomeTeamId = homeTeamId,
            AwayTeamId = awayTeamId,
            HomeTeamScore = homeTeamScore,
            AwayTeamScore = awayTeamScore,
            Status = status,
            RoundId = roundId
        };

        match.Validate();
        return match;
    }

    private void Validate()
    {
        if (HomeTeamScore < 0 || AwayTeamScore < 0)
        {
            throw new ArgumentException("Pontuações dos times devem ser números positivos.");
        }

        if (MatchDate < DateTime.Today)
        {
            throw new ArgumentException("A data do jogo deve ser no futuro.");
        }
    }
}
