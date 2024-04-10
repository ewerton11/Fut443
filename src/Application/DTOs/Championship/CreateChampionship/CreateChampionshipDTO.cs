using Domain.Enums;

namespace Application.DTOs.Championship.CreateChampionship;

public class CreateChampionshipDTO
{
    public string Name { get; set; } = string.Empty;
    public int TotalRounds { get; set; }
    public int Season { get; set; }
    public ChampionshipStatus Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
