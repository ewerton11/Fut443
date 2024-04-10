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
    public List<Round> Rounds { get; private set; }
    public List<ClubChampionship> ClubChampionships { get; private set; }

    private ChampionshipEntity()
    {
        ClubChampionships = new List<ClubChampionship>();
        Rounds = new List<Round>();
    }

    public static ChampionshipEntity Create(string name, int totalRounds, int season, ChampionshipStatus status, 
        DateTime startDate, DateTime endDate, AdminLevel currentAdminLevel)
    {
        //Fazer validações para garantir que os dados necessários estejam presentes e sejam válidos

        if (currentAdminLevel < AdminLevel.HighAdmin)
        {
            throw new UnauthorizedAccessException("Only high-level admins can create championships.");
        }

        if (endDate <= startDate)
        {
            throw new ArgumentException("End date must be after the start date.");
        }

        var championship = new ChampionshipEntity
        {
            Name = name,
            TotalRounds = totalRounds,
            Season = season,
            Status = status,
            StartDate = startDate,
            EndDate = endDate,
        };

        return championship;
    }
}