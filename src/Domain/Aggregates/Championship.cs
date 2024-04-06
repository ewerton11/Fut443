using Domain.Entities.Base;
using Domain.Enums;
using System.Text.RegularExpressions;

namespace Domain.Aggregates;

public class Championship : BaseEntity
{
    public string Name { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public List<Club> Clubs { get; private set; }
    public string CurrentPhase { get; private set; }
    public int TotalRounds { get; private set; }
    public List<Round> Rounds { get; private set; }

    private Championship() { }

    public static Championship Create(string name, DateTime startDate, DateTime endDate)
    {
        var championship = new Championship
        {
            Name = name,
            StartDate = startDate,
            EndDate = endDate,
            Rounds = new List<Round>()
        };

        return championship;
    }

    public void AddTeam(Club club)
    {
        if (!Clubs.Contains(club))
        {
            Clubs.Add(club);
        }
    }
}