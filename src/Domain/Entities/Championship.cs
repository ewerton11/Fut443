using Domain.Aggregates;
using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class ChampionshipEntity : BaseEntity
{
    public string Name { get; private set; } = null!;
    public int TotalRounds { get; private set; }
    public int CurrentPhase { get; private set; }
    public int Season { get; private set; }
    public ChampionshipStatus Status { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public List<Round> Rounds { get; private set; } = new List<Round>();
    public List<Competition>? Competitions { get; private set; }
    public List<ClubChampionship> ClubChampionships { get; private set; } = new List<ClubChampionship>();

    private ChampionshipEntity() { }

    public static ChampionshipEntity Create(string name, int totalRounds, int season,
        DateTime startDate, DateTime endDate, AdminLevel currentAdminLevel)
    {
        if (currentAdminLevel < AdminLevel.HighAdmin)
        {
            throw new UnauthorizedAccessException("Only high-level admins can create championships.");
        }

        if (endDate <= startDate)
        {
            throw new ArgumentException("End date must be after the start date.");
        }

        int currentYear = DateTime.Now.Year;
        if (season < currentYear)
        {
            throw new ArgumentException("Season cannot be in previous years.");
        }

        var championship = new ChampionshipEntity
        {
            Name = name,
            TotalRounds = totalRounds,
            CurrentPhase = 1,
            Season = season,
            Status = ChampionshipStatus.Scheduled,
            StartDate = startDate,
            EndDate = endDate,
        };

        return championship;
    }

    public void AddRound(Round round)
    {
        Rounds.Add(round);
    }

    public void UpdateCurrentPhase()
    {
        if (CurrentPhase < TotalRounds)
        {
            CurrentPhase++;
        }
        else
        {
            Status = ChampionshipStatus.Completed;
        }
    }
}